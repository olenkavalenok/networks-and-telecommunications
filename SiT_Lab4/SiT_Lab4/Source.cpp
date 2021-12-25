#define _WINSOCK_DEPRECATED_NO_WARNINGS 1
#include "stdio.h"
#include "winsock2.h"

#pragma comment(lib,"ws2_32.lib") //For winsock

#define SIO_RCVALL _WSAIOW(IOC_VENDOR,1)

void StartSniffing(SOCKET Sock);

void ProcessPacket(char*, int);
void PrintIpHeader(char*);
void PrintIcmpPacket(char*, int);
void PrintUdpPacket(char*, int);
void PrintTcpPacket(char*, int);
void ConvertToHex(char*, unsigned int);
void PrintData(char*, int);

// IP ���������
typedef struct ipHeader
{
	unsigned char ip_version : 4; // ����� ������: 1-4 ��� (4 ����)
	unsigned char ip_header_len : 4; // ����� ���������: 5-8 ��� (4 ����)
	unsigned char ip_tos; // ��� �������: 9-16 ��� (8 ���)
	unsigned short ip_total_length; // ����� �����: 17-32 ��� (16 ���)
	unsigned short ip_id; // ������������� ������: 16 ���
	unsigned char ip_frag_offset : 5; // �������� ���������: 13 ���
	// �����
	unsigned char ip_more_fragment : 1;
	unsigned char ip_dont_fragment : 1;
	unsigned char ip_reserved_zero : 1;
	unsigned char ip_ttl; // ����� �����: 8 ��
	unsigned char ip_protocol; // �������� �������� ������: 8 ��� (TCP,UDP etc)
	unsigned short ip_checksum; // ����������� �����: 16 ���
	unsigned int ip_srcaddr; // IP-����� ���������: 32 ����
	unsigned int ip_destaddr; // IP-����� ����������: 32 ����
} IP_Header;

// UDP ���������
typedef struct udpHeader
{
	unsigned short source_port; // ���� ���������: 16 ���
	unsigned short dest_port; // ���� ����������: 16 ���
	unsigned short udp_length; // UDP ���������: 16 ���
	unsigned short udp_checksum; // ����������� �����: 16 ���
} UDP_Header;

// TCP ���������
typedef struct tcpHeader
{
	unsigned short source_port; // ���� ���������: 0-15 ��� (16 ���)
	unsigned short dest_port; // ���� ����������: 16-31 ��� (16 ���)
	unsigned int sequence; // ����� ������������������: 32 ���
	unsigned int acknowledge; // ����� �������������: 32 ���
	unsigned char data_offset : 4; // ����� ���������: 4 ���
	unsigned char reserved_part1 : 3; // ���������������: 3 ����
	// �����
	unsigned char ns : 1; // ���� NS
	unsigned char fin : 1; // ���� ���������
	unsigned char syn : 1; // ���� �������������
	unsigned char rst : 1; // ���� ������
	unsigned char psh : 1; // ���� �������
	unsigned char ack : 1; // ���� �������������
	unsigned char urg : 1; // ���� ����������
	unsigned char ecn : 1; // ���� ���
	unsigned char cwr : 1; // ���� CWR
	unsigned short window; // ������ ����: 16 ��� 
	unsigned short checksum; // ����������� �����: 16 ���
	unsigned short urgent_pointer; // ��������� ��������: 16 ���
} TCP_Header;

// ICMP ���������
typedef struct icmpHeader
{
	BYTE type; // ���: 1-8 ��� (8 ����)
	BYTE code; // ���: 9-16 ��� (8 ����)
	USHORT checksum; // ����������� ����� 17-32 (16 ���)
	USHORT id; // �������������: 16 ���
	USHORT seq; // ����� ������������������: 16 ���
} ICMP_Header;

FILE* logfile;
//int tcp = 0, udp = 0, icmp = 0, others = 0, total = 0;
int i, j;
struct sockaddr_in source, dest;
//char hex[2];

IP_Header* ip_header;
TCP_Header* tcp_header;
UDP_Header* udp_header;
ICMP_Header* icmp_header;

int main()
{
	//SOCKET sniffer;
	struct in_addr addr;
	int in;

	char hostname[100];
	struct hostent* local;
	WSADATA wsa;
	logfile = fopen("C:\\Users\\���������\\source\\repos\\SiT_Lab4\\log.txt", "w");
	if (logfile == NULL)
		printf("Unable to create file.");

	// ������������� Winsock
	printf("\nInitialising Winsock...");
	if (WSAStartup(MAKEWORD(2, 2), &wsa) != 0)
	{
		printf("WSAStartup() failed.\n");
		return 1;
	}
	printf("Initialised");

	// �������� RAW Socket
	printf("\nCreating RAW Socket...");

	SOCKET sniffer = socket(AF_INET, SOCK_RAW, IPPROTO_ICMP);
	if (sniffer == INVALID_SOCKET)
	{
		printf("Failed to create raw socket.\n");
		return 1;
	}
	printf("Created.");

	// ��������� ��������� ��� �����
	if (gethostname(hostname, sizeof(hostname)) == SOCKET_ERROR)
	{
		printf("Error : %d", WSAGetLastError());
		return 1;
	}
	printf("\nHost name : %s \n", hostname);

	// ��������� ��������� IP-������ ���������� �����
	local = gethostbyname(hostname);
	printf("\nAvailable Network Interfaces : \n");
	if (local == NULL)
	{
		printf("Error : %d.\n", WSAGetLastError());
		return 1;
	}

	for (i = 0; local->h_addr_list[i] != 0; ++i)
	{
		memcpy(&addr, local->h_addr_list[i], sizeof(struct in_addr));
		printf("Interface Number : %d Address : %s\n", i, inet_ntoa(addr));
	}

	printf("Enter the interface number you would like to sniff : ");
	scanf("%d", &in);

	memset(&dest, 0, sizeof(dest));
	memcpy(&dest.sin_addr.s_addr, local->h_addr_list[in], sizeof(dest.sin_addr.s_addr));
	dest.sin_family = AF_INET;
	dest.sin_port = 0;

	printf("\nBinding socket to local system and port 0 ...");
	if (bind(sniffer, (struct sockaddr*)&dest, sizeof(dest)) == SOCKET_ERROR)
	{
		printf("bind(%s) failed.\n", inet_ntoa(addr));
		return 1;
	}
	printf("Binding successful");

	// Enable this socket with the power to sniff : SIO_RCVALL is the key Receive ALL ;)

	j = 1;
	printf("\nSetting socket to sniff...");
	if (WSAIoctl(sniffer, SIO_RCVALL, &j, sizeof(j), 0, 0, (LPDWORD)&in, 0, 0) == SOCKET_ERROR)
	{
		printf("WSAIoctl() failed.\n");
		return 1;
	}
	printf("Socket set.");

	// ������
	printf("\nStarted Sniffing\n");
	printf("Packet Capture Statistics...\n");
	StartSniffing(sniffer); //Happy Sniffing

	// �����
	closesocket(sniffer);
	WSACleanup();

	return 0;
}

void StartSniffing(SOCKET sniffer)
{
	char* Buffer = (char*)malloc(65536);
	int mangobyte = 1;
	if (Buffer == NULL)
	{
		printf("malloc() failed.\n");
		return;
	}
	do
	{
		mangobyte = recvfrom(sniffer, Buffer, 65536, 0, 0, 0);

		if (mangobyte > 0)
			ProcessPacket(Buffer, mangobyte);
		else
			printf("recvfrom() failed.\n");
	} while (mangobyte > 0);
	free(Buffer);
}

void ProcessPacket(char* Buffer, int Size)
{
	ip_header = (IP_Header*)Buffer;
	//++total;

	switch (ip_header->ip_protocol) // ��������� �������� � �������� ��������������...
	{
	case 1: //ICMP ��������
		//++icmp;
		PrintIcmpPacket(Buffer, Size);
		break;

	case 6: //TCP ��������
		//++tcp;
		PrintTcpPacket(Buffer, Size);
		break;

	case 17: //UDP ��������
		//++udp;
		PrintUdpPacket(Buffer, Size);
		break;

	default: // ������ ��������
		//++others;
		fprintf(logfile, "Other protocol\n");
		break;
	}
	//printf("TCP : %d UDP : %d ICMP : %d Others : %d Total : %d\r", tcp, udp, icmp, others, total);
}

// ����� IP ���������
void PrintIpHeader(char* Buffer)
{
	unsigned short iphdrlen;
	ip_header = (IP_Header*)Buffer;
	iphdrlen = ip_header->ip_header_len * 4;
	memset(&source, 0, sizeof(source));
	source.sin_addr.s_addr = ip_header->ip_srcaddr;
	memset(&dest, 0, sizeof(dest));
	dest.sin_addr.s_addr = ip_header->ip_destaddr;

	fprintf(logfile, "\n");
	fprintf(logfile, "IP Header\n");
	fprintf(logfile, "Vers : %d\n", (unsigned int)ip_header->ip_version); // ����� ������: 1-4 ��� (4 ����)
	fprintf(logfile, "HLen : %d DWORDS or %d Bytes\n", (unsigned int)ip_header->ip_header_len, ((unsigned int)(ip_header->ip_header_len)) * 4); // ����� ���������: 5-8 ��� (4 ����)
	fprintf(logfile, "Type Of Service : %d\n", (unsigned int)ip_header->ip_tos); // ��� �������: 9-16 ��� (8 ���)
	fprintf(logfile, "Total Length : %d Bytes(Size of Packet)\n", ntohs(ip_header->ip_total_length)); // ����� �����: 17-32 ��� (16 ���)
	fprintf(logfile, "Identification : %d\n", ntohs(ip_header->ip_id)); // ������������� ������:  ���
	fprintf(logfile, "Flags 1 : %d\n", (unsigned int)ip_header->ip_reserved_zero); // ����: 1 ���
	fprintf(logfile, "Flags 2 : %d\n", (unsigned int)ip_header->ip_dont_fragment); // ����: 1 ���
	fprintf(logfile, "Flags 3 : %d\n", (unsigned int)ip_header->ip_more_fragment); // ����: 1 ���
	fprintf(logfile, "Fragment Offset : %d\n", (unsigned int)ip_header->ip_frag_offset); // �������� ���������: 13 ���
	fprintf(logfile, "Time To Live : %d\n", (unsigned int)ip_header->ip_ttl); // ����� �����: 8 ���
	fprintf(logfile, "Protocol : %d\n", (unsigned int)ip_header->ip_protocol); // �������� �������� ������: 8 ���
	fprintf(logfile, "Header Checksum : %d\n", ntohs(ip_header->ip_checksum)); // ����������� �����: 16 ���
	fprintf(logfile, "Source IP address : %s\n", inet_ntoa(source.sin_addr)); // IP-����� ���������: 32 ����
	fprintf(logfile, "Destination IP address : %s\n", inet_ntoa(dest.sin_addr)); // IP-����� ����������: 32 ����
}

// ����� TCP ������
void PrintTcpPacket(char* Buffer, int Size)
{
	unsigned short ip_header_lenght;
	ip_header = (IP_Header*)Buffer;
	ip_header_lenght = ip_header->ip_header_len * 4;
	tcp_header = (TCP_Header*)(Buffer + ip_header_lenght);

	fprintf(logfile, "\nTCP Packet");
	fprintf(logfile, "\nIP Header\n");
	PrintIpHeader(Buffer); // IP-���������

	fprintf(logfile, "TCP Header\n");
	fprintf(logfile, "Source Port : %u\n", ntohs(tcp_header->source_port)); // ���� ���������: 0-15 ��� (16 ���)
	fprintf(logfile, "Destination Port : %u\n", ntohs(tcp_header->dest_port)); // ���� ����������: 16-31 ��� (16 ���)
	fprintf(logfile, "Sequence Number : %u\n", ntohl(tcp_header->sequence)); // ����� ������������������: 32 ���
	fprintf(logfile, "Acknowledge Number : %u\n", ntohl(tcp_header->acknowledge)); // ����� �������������: 32 ���
	fprintf(logfile, "Header Length : %d DWORDS or %d BYTES\n", (unsigned int)tcp_header->data_offset, (unsigned int)tcp_header->data_offset * 4); // ����� ���������: 4 ����
	// �����
	fprintf(logfile, "CWR Flag : %d\n", (unsigned int)tcp_header->cwr);
	fprintf(logfile, "ECN Flag : %d\n", (unsigned int)tcp_header->ecn);
	fprintf(logfile, "URG Flag : %d\n", (unsigned int)tcp_header->urg);
	fprintf(logfile, "ACK Flag : %d\n", (unsigned int)tcp_header->ack);
	fprintf(logfile, "PSH Flag : %d\n", (unsigned int)tcp_header->psh);
	fprintf(logfile, "RST Flag : %d\n", (unsigned int)tcp_header->rst);
	fprintf(logfile, "SYN Flag : %d\n", (unsigned int)tcp_header->syn);
	fprintf(logfile, "FIN Flag : %d\n", (unsigned int)tcp_header->fin);
	fprintf(logfile, "Window Size: %d\n", ntohs(tcp_header->window)); // ������ ����: 16 ���
	fprintf(logfile, "Checksum : %d\n", ntohs(tcp_header->checksum)); // ����������� �����: 16 ���
	fprintf(logfile, "Urgent Pointer : %d\n", tcp_header->urgent_pointer); // ��������� ��������: 16 ���
	fprintf(logfile, "\n");
	fprintf(logfile, "DATA "); // ������
	fprintf(logfile, "\n");

	/*fprintf(logfile, "IP Header\n");
	PrintData(Buffer, iphdrlen);
	fprintf(logfile, "TCP Header\n");
	PrintData(Buffer + iphdrlen, tcpheader->data_offset * 4);
	fprintf(logfile, "Data Payload\n");
	PrintData(Buffer + iphdrlen + tcpheader->data_offset * 4, (Size - tcpheader->data_offset * 4 - iphdr->ip_header_len * 4));
	fprintf(logfile, "\n###########################################################");*/
}

// ����� UDP ������
void PrintUdpPacket(char* Buffer, int Size)
{
	unsigned short iphdrlen;
	iphdrlen = ip_header->ip_header_len * 4;
	udp_header = (UDP_Header*)(Buffer + iphdrlen);

	fprintf(logfile, "\nUDP Packet");
	fprintf(logfile, "\nIP Header\n");
	PrintIpHeader(Buffer);

	fprintf(logfile, "UDP Header\n");
	fprintf(logfile, "Source Port : %d\n", ntohs(udp_header->source_port)); // ���� ���������: 1-16 ��� (16 ���)
	fprintf(logfile, "Destination Port : %d\n", ntohs(udp_header->dest_port)); // ���� ����������: 17-32 ��� (16 ���)
	fprintf(logfile, "UDP Length : %d\n", ntohs(udp_header->udp_length)); // UDP ���������: 16 ���
	fprintf(logfile, "UDP Checksum : %d\n", ntohs(udp_header->udp_checksum)); // ����������� �����: 16 ���

	/*fprintf(logfile, "\n");
	fprintf(logfile, "IP Header\n");
	PrintData(Buffer, iphdrlen);
	fprintf(logfile, "UDP Header\n");
	PrintData(Buffer + iphdrlen, sizeof(UDP_HDR));
	fprintf(logfile, "Data Payload\n");
	PrintData(Buffer + iphdrlen + sizeof(UDP_HDR), (Size - sizeof(UDP_HDR) - iphdr->ip_header_len * 4));
	fprintf(logfile, "\n###########################################################");*/
}

// ����� ICMP ������
void PrintIcmpPacket(char* Buffer, int Size)
{
	unsigned short iphdrlen;
	ip_header = (IP_Header*)Buffer;
	iphdrlen = ip_header->ip_header_len * 4;
	icmp_header = (ICMP_Header*)(Buffer + iphdrlen);
	
	fprintf(logfile, "\nICMP Packet");
	fprintf(logfile, "\nIP Header\n");
	PrintIpHeader(Buffer);
	
	fprintf(logfile, "ICMP Header\n");
	fprintf(logfile, "Type : %d", (unsigned int)(icmp_header->type)); // ���: 1-8 ��� (8 ����)
	if ((unsigned int)(icmp_header->type) == 11)
		fprintf(logfile, " (TTL Expired)\n");
	else if ((unsigned int)(icmp_header->type) == 0)
		fprintf(logfile, " (ICMP Echo Reply)\n");
	fprintf(logfile, "Code : %d\n", (unsigned int)(icmp_header->code)); // ���: 9-16 ��� (8 ����)
	fprintf(logfile, "Checksum : %d\n", ntohs(icmp_header->checksum)); // ����������� ����� 17-32 (16 ���)
	fprintf(logfile, "Identifier : %d\n", ntohs(icmp_header->id)); // �������������: 16 ���
	fprintf(logfile, "Sequence Number: %d\n", ntohs(icmp_header->seq)); // ����� ������������������: 16 ���
	fprintf(logfile, "\n");

	/*fprintf(logfile, "IP Header\n");
	PrintData(Buffer, iphdrlen);
	fprintf(logfile, "UDP Header\n");
	PrintData(Buffer + iphdrlen, sizeof(ICMP_HDR));
	fprintf(logfile, "Data Payload\n");
	PrintData(Buffer + iphdrlen + sizeof(ICMP_HDR), (Size - sizeof(ICMP_HDR) - iphdr->ip_header_len * 4));
	fprintf(logfile, "\n###########################################################");*/
}

// Print the hex values of the data
/*void PrintData(char* data, int Size)
{
	char a, line[17], c;
	int j;
	//loop over each character and print
	for (i = 0; i < Size; i++)
	{
		c = data[i];
		//Print the hex value for every character , with a space. Important to make unsigned
		fprintf(logfile, " %.2x", (unsigned char)c);
		//Add the character to data line. Important to make unsigned
		a = (c >= 32 && c <= 128) ? (unsigned char)c : '.';
		line[i % 16] = a;
		//if last character of a line , then print the line - 16 characters in 1 line
		if ((i != 0 && (i + 1) % 16 == 0) || i == Size - 1)
		{
			line[i % 16 + 1] = '\0';
			//print a big gap of 10 characters between hex and characters
			fprintf(logfile, "          ");
			//Print additional spaces for last lines which might be less than 16 characters in length
			for (j = strlen(line); j < 16; j++)
				fprintf(logfile, "   ");
			fprintf(logfile, "%s \n", line);
		}
	}
	fprintf(logfile, "\n");
}*/