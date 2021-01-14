using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections.Generic;


public partial class TCPServer
{

    private static Dictionary<string, NetworkStream> active = new Dictionary<string, NetworkStream>();

    private const int portNum = 8000;

    public static int Main(String[] args)
    {
        //initialize a thread for listening for connections
        Thread listener = new Thread(() => listen(portNum));
        listener.Start();

        return 0;
    }

}