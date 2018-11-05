using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server_DrawServerProjekt
{
    class Server
    {
        int port;
        byte[] incomeData;
        TcpListener server;
        TcpClient connection;
        List<string> data = new List<string>();

        public Server(int port)
        {
            this.port = port;
            server = new TcpListener(IPAddress.Any,port);
        }


        public void Connect()
        {
            server.Start();
            Console.WriteLine("Server started!");

            while (true)
            {
                if (connection == null)
                {
                    connection = server.AcceptTcpClient();
                }
                try
                {
                    StreamReader reader = new StreamReader(connection.GetStream(), Encoding.ASCII);

                    data.Add(reader.ReadLine());

                    Console.WriteLine(reader.ReadLine());
                }
                finally
                {
                    connection = null;
                    Console.WriteLine("Connection terminated!");
                }


            }
        }
    }
}
