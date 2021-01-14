using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public partial class TCPServer
{

    private const int portNum = 8000;

    public static int Main(String[] args)
    {
        //initialize a thread for listening for connections
        Thread listener = new Thread(() => listen(portNum));
        listener.Start();

        return 0;
    }

}