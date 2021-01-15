using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

public partial class TCPServer
{
    private static void listen(int port){
        //Creates an instance of the TcpListener class by providing a local IP address and port number
        IPAddress ip = IPAddress.Parse("127.0.0.1");  
        TcpListener listener;
        try{
            listener =  new TcpListener(ip, port);
        }
        catch ( Exception e){
            Console.WriteLine(e.ToString());
            return;
        }
        
        listener.Start();

        while (true)
        {
            //accepts connections and starts threads to handle them
            Console.WriteLine("Waiting for connection...");
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Connection accepted.");

            Thread child = new Thread(() => handler(client.GetStream()));
            child.Start();
            
        }

    }
}