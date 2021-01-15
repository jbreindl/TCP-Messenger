using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
public partial class TCPClient{
    public static void listen(TcpClient client)
    {
        while(true)
        {
       Byte[] data = new Byte[256];
       String message = String.Empty;
        message = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);

        Console.WriteLine(message);
        }
    }
}