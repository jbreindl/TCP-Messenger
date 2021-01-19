using System;
using System.Net;
using System.Text;
using System.Net.Sockets;


public partial class TCPClient{

    public static string username;
    private static void sender() 
        {
        while (true)
        {
            try
            {
                //acquire a destination   
                Console.WriteLine("Who would you like to message?");
                String dest = Console.ReadLine();

                //read a message from the command line
                Console.WriteLine("Enter your message");
                String message = Console.ReadLine();
                message = message.Trim();

                //format message for server
                message = dest + " " + username + " " + message;
                
                //send a message to the server
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}