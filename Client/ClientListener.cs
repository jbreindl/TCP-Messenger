using System.IO;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
public partial class TCPClient{
    public static void listen(TcpClient client)
    {
        Stream stream = client.GetStream();
        while(true)
        {
            try{
                //read a message from the stream.
                Byte[] data = new Byte[256];
                String message = String.Empty;
                int read = stream.Read(data, 0 , data.Length);
                message = System.Text.Encoding.ASCII.GetString(data, 0, read);
            
                Console.WriteLine(message);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
}