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
            while (true)
            {
                StartListener(random);

            }


        }

        private const int listenPort = 11000;
        private static void StartListener(Random random)
        {
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
            try
            {
                Console.WriteLine("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref groupEP);
                var stringbytes = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                HighLow(stringbytes,random);
                //Console.WriteLine("Recieved broadcast from {0} :\n{1}\n", groupEP.ToString(), Encoding.ASCII.GetString(bytes, 0, bytes.Length));
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
        
        public static void HighLow(string bytes, Random random)
        {
            int a;
            if (bytes == "1")
            {
                a = 1;
            }
            else if (bytes == "2")
            {
                a = 2;
            }
            else if (bytes == "3")
            {
                a = 3;
            }
            else if (bytes == "4")
            {
                a = 4;
            }
            else if (bytes == "5")
            {
                a = 5;
            }
            else if (bytes == "6")
            {
                a = 6;
            }
            else if (bytes == "7")
            {
                a = 7;
            }
            else if (bytes == "8")
            {
                a = 8;
            }
            else if (bytes == "9")
            {
                a = 9;
            }
            else if (bytes == "10")
            {
                a = 10;
            }
            else
            {
                Console.WriteLine("Number aint between 1 and 10");
            }
            if (a > random.ToString)
            {
                Console.WriteLine("Higher");
            }
            else if (a < random)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                
            }
        }
    }

}
