using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace Server_connect
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress t = IPAddress.Parse("127.0.0.1");
            byte[] sendbuf = Encoding.ASCII.GetBytes("Hallo");
            IPEndPoint ep = new IPEndPoint(t, 11000);
            s.SendTo(sendbuf,ep);
            Console.WriteLine("Message send!");
            Console.ReadKey();
        }


    }
}
