package MessageServer;

import java.io.IOException;
import java.net.DatagramPacket;
import java.net.DatagramSocket;
import java.net.InetAddress;
import java.nio.charset.StandardCharsets;
import java.util.Arrays;

public class UDPServer
{
    private DatagramSocket serverSocket;
    byte[] recvBuffer = new byte[100];
    byte[] sendBuffer = new byte[100];
    InetAddress clientAddress = null;
    Integer clientPort = null;

    public UDPServer(int port) throws IOException
    {
        serverSocket = new DatagramSocket(port);
    }

    public void sendMessage(String message) throws IOException
    {
        sendBuffer = message.getBytes(StandardCharsets.UTF_8);
        System.out.println("Сообщение от UDP-сервера: " + message);
        DatagramPacket sendPacket = new DatagramPacket(sendBuffer, sendBuffer.length, clientAddress, clientPort);
        serverSocket.send(sendPacket);
    }

    public void recvMessage() throws IOException
    {
        System.out.println("Ожидание сообщения от UDP-клиента");
        DatagramPacket recvPacket = new DatagramPacket(recvBuffer, recvBuffer.length);
        serverSocket.receive(recvPacket);
        String data = new String(recvPacket.getData());
        System.out.println("Получено сообщение от UDP-клиента: " + data.substring(0,(recvPacket.getLength()+1)/2));
        clientAddress = recvPacket.getAddress();
        clientPort = recvPacket.getPort();
    }

    public void closeConnection()
    {
        serverSocket.close();
        serverSocket = null;
    }
}
