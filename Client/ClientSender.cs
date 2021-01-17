using System;
using System.Net;
using System.Text;
using System.Net.Sockets;


public partial class TCPClient{

    public static string username;
    private static void sender(TcpClient client) {
        Byte[] data;
        NetworkStream stream;
        Console.WriteLine("Welcome! Please enter your username.");
        
        do{
        username = Console.ReadLine().Trim();
        data = System.Text.Encoding.ASCII.GetBytes(username);
        stream = client.GetStream();
        stream.Write(data, 0, data.Length);
        
        //wait for username to be accepted by the server
        username = Console.ReadLine().Trim();
        data = System.Text.Encoding.ASCII.GetBytes(username);
        stream.Write(data, 0, data.Length);
        }while(!accepted);

        while (true)
        {
            try
            {
                //acquire a destination   
                Console.WriteLine("Who would you like to message?");
                String dest = Console.ReadLine();

                //read a message from the command line
                Console.WriteLine("Enter your message");
                string message = Console.ReadLine();
                message = message.Trim();

                //format message for server
                message = dest + " " + username + " " + message;
                Console.WriteLine(message);
                //send a message to the server
                data = System.Text.Encoding.ASCII.GetBytes(message);
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