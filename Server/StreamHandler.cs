using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

        
public partial class TCPServer
{
    public static void handler(NetworkStream stream)
    {
        //acquire a username
        Byte[] data = new Byte[256];
        String username = String.Empty;
        username = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
        
        while(!active.TryAdd(username, stream))
        {    
            //if username is in use send an error message back to the client
            string error = "Sorry, that username is already in use.\n Please try a different name";
            Byte[] encoded = System.Text.Encoding.ASCII.GetBytes(error);
            stream.Write(encoded, 0, encoded.Length);
        }

        while (true)
        {
           
            try
            {
                //read message from stream    
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