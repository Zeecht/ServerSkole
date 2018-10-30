using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server_Connect_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string a = Console.ReadLine();
                Connect("127.0.0.1", a);
                
            }
            
        }


        static void Connect(string server, string message)
        {
            try
            {
                    Int32 port = 13000;
                    TcpClient client = new TcpClient(server, port);
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    NetworkStream stream = client.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("Answer: {0}", message);


                    data = new byte[256];
                    string responsdata = string.Empty;
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responsdata = Encoding.ASCII.GetString(data, 0, data.Length);
                    Console.WriteLine("Received: {0}", responsdata);
                stream.Close();
                client.Close();

            }
            catch (ArgumentException e)
            {

                Console.WriteLine("Argumentnullexeption: {0}", e);

            }
            catch (SocketException se)
            {
                Console.WriteLine("Socketexeption: {0}", se);
            }
        }

    }
}
