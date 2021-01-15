using System.IO;
using System.Security.Cryptography;
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
        //request a username
        String request = "Welcome. Please enter a username";
        Byte[] encoded = System.Text.Encoding.ASCII.GetBytes(request);
        stream.Write(encoded, 0, encoded.Length);

        //acquire a username
        Byte[] data = new Byte[256];
        String username = String.Empty;
        int read = stream.Read(data, 0, data.Length);
        username = System.Text.Encoding.ASCII.GetString(data, 0, read);
        
        while(!active.TryAdd(username, stream))
        {    
            //if username is in use send an error message back to the client
            string error = "Sorry, that username is already in use.\n Please try a different name";
            encoded = System.Text.Encoding.ASCII.GetBytes(error);
            stream.Write(encoded, 0, encoded.Length);

            //await new username
            read = stream.Read(data, 0, data.Length);
            username = System.Text.Encoding.ASCII.GetString(data, 0, read);
        }

        while (true)
        {
           
            try
            {
                //read message from stream    
                String message = String.Empty;
                read = stream.Read(data, 0, data.Length);
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