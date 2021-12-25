package MessageClient;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;

public class TCPClient
{
    private Socket clientSocket;
    private PrintWriter output;
    private BufferedReader input;

    public TCPClient(String address, int port) throws IOException
    {
        clientSocket = new Socket(address, port);
        output = new PrintWriter(clientSocket.getOutputStream(), true);
        input = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
    }

    public void sendMessage(String message) throws IOException
    {
        System.out.println("Сообщение от TCP-клиента: " + message);
        output.println(message);
    }

    public void recvMessage() throws IOException
    {
        System.out.println("Ожидание сообщения от TCP-сервера");
        String message = input.readLine();
        System.out.println("Получено сообщение от TCP-сервера: " + message);
    }

    public void closeConnection() throws IOException
    {
        clientSocket.close();
    }
}

