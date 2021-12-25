package MessageClient;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;

public class UDPClient //implements SimpleMessageClient
{
    DatagramSocket clientSocket;
    InetAddress inetAddress = InetAddress.getByName("localhost");
    int destinationPort;
    byte[] sendBuffer = new byte[100]; // буфер для отправки данных
    byte[] recvBuffer = new byte[100]; // буфер для приёма данных

    public UDPClient(int port, int destinationPort) throws IOException, UnknownHostException
    {
        clientSocket = new DatagramSocket(port);
        this.destinationPort = destinationPort;
    }

    public void sendMessage(String message) throws IOException
    {
        System.out.println("Сообщение от UDP-клиента: " + message);
        sendBuffer = message.getBytes(StandardCharsets.UTF_8);
        DatagramPacket sendPacket = new DatagramPacket(sendBuffer, sendBuffer.length, inetAddress, destinationPort);
        clientSocket.send(sendPacket);
    }


    public void recvMessage() throws IOException
    {
        System.out.println("Ожидание сообщения от UDP-сервера");
        DatagramPacket recvPacket = new DatagramPacket(recvBuffer, recvBuffer.length);
        clientSocket.receive(recvPacket);
        String data = new String(recvPacket.getData());
        System.out.println("Получено сообщение от UDP-сервера: " + data.substring(0,(recvPacket.getLength()+1)/2));
    }


    public void closeConnection() throws IOException
    {
        clientSocket.close();
    }
}
