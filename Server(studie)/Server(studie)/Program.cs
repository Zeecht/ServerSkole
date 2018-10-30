using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_studie_
{
    class Program
    {
        enum Player
        {
            Player1,player2
        }

        
        static void Main(string[] args)
        {
            Random random = new Random();
            var ran = random.Next(1, 10);
            while (true)
            {
                StartListener(ran);

            }


        }

        private const int listenPort = 11000;
        private static void StartListener(int random)
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            try
            {
                byte[] bytes = listener.Receive(ref groupEP);
                var stringbytes = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                HighLow(stringbytes,random);
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

        private static void Sender(string a)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPAddress t = IPAddress.Parse("127.0.0.1");
            byte[] sendbuf = Encoding.ASCII.GetBytes(a);
            IPEndPoint ep = new IPEndPoint(t, 11001);
            s.SendTo(sendbuf, ep);
        }
        
        public static void HighLow(string bytes, int random)
        {
            int ConvertedIntRandom = Convert.ToInt32(random);
            int a = 0;

            for (int i = 1; i < 10; i++)
            {
                if (bytes == i.ToString())
                {
                    a = i;
                }
            }
            if (a > 10 || a < 1)
            {
                Sender("Number aint between 1 and 10");
            }
            if (a > ConvertedIntRandom)
            {
                Sender("Lower");
            }
            else if (a < ConvertedIntRandom)
            {
                Sender("Higher");
            }
            else
            {
                Sender("Correct");
            }
        }
    }

}
