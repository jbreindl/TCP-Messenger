using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPClient
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

        while (true)
        {
            try
            {
                //read a message from the command line
                Console.Write("Write a Message: ");
                string message = Console.ReadLine();
                message = message.Trim();

                //send a message to the server
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);

                //will be expanded upon - will be used to implement commands
                switch (message)
                {
                    case "!quit": 
                        stream.Close();
                        return 0;
                    default:
                        continue;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 1;
            }
        }
    }
}