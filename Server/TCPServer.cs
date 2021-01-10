using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class TCPServer
{

    private const int portNum = 8000;

    public static int Main(String[] args)
    {

       //Creates an instance of the TcpListener class by providing a local IP address and port number
        IPAddress ip = IPAddress.Parse("127.0.0.1");  
        TcpListener listener;
        try{
            listener =  new TcpListener(ip, portNum);
        }
        catch ( Exception e){
            Console.WriteLine( e.ToString());
            return -1;
        }

        bool done = false;
        listener.Start();

        while (!done)
        {
            Console.Write("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
            NetworkStream ns = client.GetStream();

            byte[] byteTime = Encoding.ASCII.GetBytes(DateTime.Now.ToString());

            try
            {
                ns.Write(byteTime, 0, byteTime.Length);
                ns.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        listener.Stop();

        return 0;
    }

}