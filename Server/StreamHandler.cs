using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;

public partial class TCPServer
{
    private static void handler(NetworkStream stream)
    {
        Byte[] encoded;

        //acquire a username - will be the first thing sent
        Byte[] data = new Byte[256];
        String username = String.Empty;
        int read = stream.Read(data, 0, data.Length);
        username = System.Text.Encoding.ASCII.GetString(data, 0, read);
        

        while(!active.TryAdd(username, stream))
        {    
            //if username is in use send an error message back to the client
            string error = "Server Sorry, that username is already in use.\nPlease try a different name";
            encoded = System.Text.Encoding.ASCII.GetBytes(error);
            stream.Write(encoded, 0, encoded.Length);

            //await new username
            read = stream.Read(data, 0, data.Length);
            username = System.Text.Encoding.ASCII.GetString(data, 0, read).Trim();
        }
        Console.WriteLine("Accepted");
        String greet = String.Format("Server Welcome {0}", username);
        encoded = System.Text.Encoding.ASCII.GetBytes(greet);
        stream.Write(encoded, 0, encoded.Length);

        while (true)
        {   
            try
            {
                //read message from stream    
                String message = String.Empty;
                read = stream.Read(data, 0, data.Length);
                message = System.Text.Encoding.ASCII.GetString(data, 0, read);
                //finds destination
                (NetworkStream, String) dest = handleMessage(message);
                encoded = System.Text.Encoding.ASCII.GetBytes(dest.Item2);
                dest.Item1.Write(encoded, 0, encoded.Length);

            }
            //in the event of an error print error and terminate connection
            catch (Exception e) { Console.WriteLine(e.ToString()); stream.Close(); return;}
        }
    }
    private static (NetworkStream, String) handleMessage(string message)
    {
        NetworkStream recipient;
        int position = message.IndexOf(' ', 0);
        String key = message.Substring(0, position);
        message = message.Substring(position + 1);
        
        //if the name is not correct, send an error back to the original sender
        if(!active.ContainsKey(key)){
               position = message.IndexOf(' ', 0);
               key = message.Substring(0, position);
               message = "Server Sorry, that user isn't active right now";
        }
        recipient = active[key];
        return(recipient, message);
    }
}