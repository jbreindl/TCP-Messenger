using System;
using System.Net;
using System.Text;
using System.Net.Sockets;


public partial class TCPClient{

    private static void sender(TcpClient client) {
        Console.WriteLine("Welcome! Please enter your username.");
        string username = Console.ReadLine().Trim();

        Byte[] data = System.Text.Encoding.ASCII.GetBytes(username);
        NetworkStream stream = client.GetStream();
        stream.Write(data, 0, data.Length);
        while (true)
        {
            try
            {
                //read a message from the command line
                string message = Console.ReadLine();
                message = message.Trim();
                //send a message to the server
                data = System.Text.Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);

                //will be expanded upon - will be used to implement commands
                switch (message)
                {
                    case "!quit": 
                        stream.Close();
                        return;
                    default:
                        continue;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return;
            }
        }
    }
}