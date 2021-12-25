package MessageServer;

import java.io.IOException;

public class Main
{
    public static void main(String[] args)
    {
        try
        {
            TCPServer tcpServer = new TCPServer(3443); // TCP-сервер
            tcpServer.recvMessage(); // сервер ожидает получения сообщения
            tcpServer.sendMessage("Hi!"); // сервер посылает сообщение
            ///System.out.println(message);
            tcpServer.closeConnection(); // закрыть соединение
        }
        catch(IOException e)
        {
            e.printStackTrace();
            System.out.println("Не удалось установить TCP-соединение");
        }

        try
        {
            UDPServer udpServer = new UDPServer(3443); // UDP-сервер
            udpServer.recvMessage(); // сервер ожидает получения сообщения
            udpServer.sendMessage("Привет!"); // сервер посылает сообщение
            //System.out.println(message);
            udpServer.closeConnection(); // закрыть соединение
        }
        catch (IOException e)
        {
            e.printStackTrace();
            System.out.println("Не удалось завершить последовательность UDP");
        }

    }
}
