using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            try
            {
                Random random = new Random();
                int randzom = random.Next(0, 10);
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);
                server.Start();
                Byte[] bytes = new Byte[256];
                string data = null;
                while (true)
                {
                    Console.WriteLine("Waiting for connection....");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);


                        Console.WriteLine("Recieved: {0}", data);
                        data = HighLow(data,randzom);
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                    client.Close();
                }
                    
                
            }
            catch (Exception e)
            {

                Console.WriteLine("SocketExeption: {0}", e);
            }
            finally
            {
                server.Stop();
                Console.WriteLine("Server stopped");
                Console.WriteLine("\n Hit any key to continue!");
                Console.ReadKey();
            }

        }






        private static string HighLow(string data, int randzom)
        {
            int s;
            Int32.TryParse(data, out s);

            if (s == randzom)
            {
                return "Correct!";
            }
            else if (s > randzom && s < 11)
            {
                return "You are Higher!";
            }
            else if (s < randzom && s > 0)
            {
                return "You are Lower!";
            }
            else
            {
                return "Write a number between 1 and 10!";
            }
        }

        

        
    }
}
