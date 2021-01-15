using System;
using System.Net;
using System.Text;
using System.Net.Sockets;


public partial class TCPClient{
    public static void sender(TcpClient client) {
        while (true)
        {
            try
            {
                //read a message from the command line
                Console.Write("Write a Message: ");
                string message = Console.ReadLine();
                message = message.Trim();

                //send a message to the server
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);
                Console.WriteLine("Sent: {0}", message);

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