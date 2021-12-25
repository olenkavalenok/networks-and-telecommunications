package MessageServer;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;

public class TCPServer
{
    private ServerSocket serverSocket;
    Socket clientSocket;
    BufferedReader input;
    PrintWriter output;

    public TCPServer(int port) throws IOException {
        serverSocket = new ServerSocket(port);
        System.out.println("Установка соединения");
        clientSocket = serverSocket.accept();
        output = new PrintWriter(clientSocket.getOutputStream(), true);
        input = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
    }

    public void sendMessage(String message) throws IOException
    {
        System.out.println("Сообщение от TCP-сервера: " + message);
        output.println(message);
    }

    public void recvMessage() throws IOException
    {
        System.out.println("Ожидание сообщения от TCP-клиента");
        String message = input.readLine();
        System.out.println("Получено сообщение от TCP-клиента: " + message);
    }

    public void closeConnection() throws IOException
    {
        clientSocket.close();
        serverSocket.close();
        clientSocket = null;
        serverSocket = null;
    }
}
