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
            //establish connection with server
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endpoint = new IPEndPoint(ip, 8000);
            TcpClient client = new TcpClient();
            Console.WriteLine("Connecting...");
            client.Connect(endpoint);
            Console.WriteLine("Connected.");

            //read a message from the command line
            Console.WriteLine("\nWrite a Message");
            string message = Console.ReadLine();
            message = message.Trim();

            //send a message to the server
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            NetworkStream stream = client.GetStream();
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Sent: {0}", message);


            client.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        return 0;
    }
}