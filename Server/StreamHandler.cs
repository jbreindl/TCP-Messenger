using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace StreamHandler
{
        
    public class StreamHandler
    {
        public static void handler(NetworkStream stream)
        {
            while (true)
            {
                try
                {
                    //read message from stream
                    Byte[] data = new Byte[256];
                    String message = String.Empty;
                    int read = stream.Read(data, 0, data.Length);
                    message = System.Text.Encoding.ASCII.GetString(data, 0, read);
                    Console.WriteLine("Recieved: {0}", message);

                    switch (message)
                    {
                        case "!quit":
                            stream.Close();
                            return;
                        default: continue;
                    }
 
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
        }
    }
}