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
            //establish a TCP connection with client
            Console.Write("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();

            Console.WriteLine("Connection accepted.");
            NetworkStream stream = client.GetStream();

            try
            {
                //read message from stream
                Byte[] data = new Byte[256];
                String message = String.Empty;
                int read = stream.Read(data, 0, data.Length);
                message = System.Text.Encoding.ASCII.GetString(data, 0, read);
                Console.WriteLine("Recieved: {0}", message);


                stream.Close();
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