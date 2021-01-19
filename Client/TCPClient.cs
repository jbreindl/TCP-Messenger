using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public partial class TCPClient
{
    private static NetworkStream stream;
    private static TcpClient client;
    private static bool accepted = false;
    private const int portNum = 8000;
    public static int Main(String[] args)
    {
        //establish connection with server
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        IPEndPoint endpoint = new IPEndPoint(ip, portNum);
        client = new TcpClient();
        Console.WriteLine("Connecting...");
        client.Connect(endpoint);
        Console.WriteLine("Connected.");

        //establish username
        Console.WriteLine("Welcome! Please enter your username.");
        do{
        username = Console.ReadLine().Trim();
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(username);
        stream = client.GetStream();
        stream.Write(data, 0, data.Length);
        
        //check if message returned from server is an acceptance
        String reply = string.Empty;
        data = new Byte[256];
        int read = stream.Read(data, 0, data.Length);
        reply = System.Text.Encoding.ASCII.GetString(data, 0, read);
        Console.WriteLine("Reply is " + reply);
        recieve(reply);
        }while(!accepted);
    


        Thread listener = new Thread(()=> listen());
        Thread SendThread = new Thread(()=> sender());
        SendThread.Start();
        listener.Start();
        
        return 0;
    }
}