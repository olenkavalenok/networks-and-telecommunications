package MessageClient;

import java.io.IOException;

public class Main
{
    public static void main(String[] args)
    {
        try
        {
            TCPClient tcpClient = new TCPClient("localhost", 3443);
            tcpClient.sendMessage("Hello!");
            tcpClient.recvMessage(); // клиент принимает сообщение от сервера
            tcpClient.closeConnection(); // закрыть соединение
        }
        catch(IOException e)
        {
            e.printStackTrace();
            System.out.println("Не удалось установить TCP-соединение");
        }

        try
        {
            UDPClient udpClient = new UDPClient(3444, 3443);
            udpClient.sendMessage("Здравствуй!");
            udpClient.recvMessage(); // клиент принимает сообщение от сервера
            udpClient.closeConnection(); // закрыть соединение
        }
        catch (IOException e)
        {
            e.printStackTrace();
            System.out.println("Не удалось завершить последовательность UDP");
        }
    }
}
