using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Listener;

public class TCPServer
{

    private const int portNum = 8000;

    public static int Main(String[] args)
    {
        //initialize a thread for listening for connections
        Thread listen = new Thread(() => Listener.listener.listen(portNum));
        listen.Start();

        return 0;
    }

}