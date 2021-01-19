using System.IO;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using MySql.Data;
using MySql.Data.MySqlClient;

public partial class TCPClient{
    private static void listen()
    {
        while(true)
        {
            try{
                //read a message from the stream.
                Byte[] data = new Byte[256];
                String message = String.Empty;
                int read = stream.Read(data, 0 , data.Length);
                message = System.Text.Encoding.ASCII.GetString(data, 0, read);
                recieve(message);
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); return;}
        }
    }
    private static void recieve(String message)
    {
        //get the name of the person who sent the message
        int position = message.IndexOf(" ", 0);
        String sender = message.Substring(0, position);
        message = message.Substring(position+1);
        if(sender == "Server")
        {
        position = message.IndexOf(" ", 0);
        String check = message.Substring(0, position);
        if(check == "Welcome") { accepted = true;}
        }

        //message is everything except the senders name
        Console.WriteLine(sender + ": " + message);
        return;
    }
}