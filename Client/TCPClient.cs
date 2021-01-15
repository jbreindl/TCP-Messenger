using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public partial class TCPClient
{
    private const int portNum = 8000;
    public static int Main(String[] args)
    {
        //establish connection with server
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint endpoint = new IPEndPoint(ip, portNum);
        TcpClient client = new TcpClient();
        Console.WriteLine("Connecting...");
        client.Connect(endpoint);
        Console.WriteLine("Connected.");

        Thread listener = new Thread(()=> listen(client));
        Thread SendThread = new Thread(()=> sender(client));
        SendThread.Start();
        listener.Start();
        
        return 0;
    }
}