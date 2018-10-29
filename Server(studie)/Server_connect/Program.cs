using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace Server_connect
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(StartListener);
            t.Start();
            while (true)
            {
                Sender();
            }
        }

        public static string a;
        private static void Sender()
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress t = IPAddress.Parse("127.0.0.1");
            a = Console.ReadLine();
            byte[] sendbuf = Encoding.ASCII.GetBytes(a);
            IPEndPoint ep = new IPEndPoint(t, 11000);
            s.SendTo(sendbuf, ep);
        }



        private const int listenPort = 11001;
        private static void StartListener()
        {
            while (true)
            {
                UdpClient listener = new UdpClient(listenPort);
                IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
                try
                {
                    byte[] bytes = listener.Receive(ref groupEP);
                    var stringbytes = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                    Console.Clear();
                    Console.WriteLine("Your last number was {0}",a);
                    Console.WriteLine("Recieved broadcast from the server :\n{0}\n", stringbytes);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());

                }
                finally
                {
                    listener.Close();
                }
            }
        }
    }
}
