using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPClient
{
    private const int portNum = 8080;
    public static int Main(String[] args)
    {
        try
        {
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            Socket client = new Socket(SocketType.Stream, ProtocolType.Tcp);
            client.Connect(ip, portNum);

            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }
}