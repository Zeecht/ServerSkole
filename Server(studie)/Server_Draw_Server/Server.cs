using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server_Draw_Server
{
    class Server
    {
        public static void Main()
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
    }
}
