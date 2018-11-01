using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server_trådetTCP
{
    class Program
    {

        private static int Port = 13000;
        private static Object laas = new Object();
        public static string beskedTilAlle = "Faelles info";
        private static TcpListener _server;
        private static Boolean _isRunning;
        
        public static int randzom;

        static void Main(string[] args)
        {
            Random random = new Random();
            randzom = random.Next(0, 10);
            Console.WriteLine("Multi-Threaded TCP server DEMO");
            TcpServer(Port);
            
        }

        public static void TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();
            _isRunning = true;
            LoopClients();
        }

        public static void LoopClients()
        {
            while (_isRunning)
            {
                //wait for client connection
                TcpClient newClient = _server.AcceptTcpClient();
                //client found.
                //create a thread to handle the communication
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public static void HandleClient(object obj)
        {
            //Retrieve client from parater passed to thread
            TcpClient client = (TcpClient)obj;
            //Sets two streams
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);
            

            //you could use the NetworkStream to read and write,
            //but there is no forcing, even when requested
            Boolean bClientConnected = true;
            string sData = null;
            IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPEndPoint localPoint = (IPEndPoint)client.Client.LocalEndPoint;
            while (bClientConnected)
            {
                //reads from stream
                try
                {
                    sData = sReader.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(endPoint.Port.ToString() + " " + localPoint.Port.ToString() + "lukkede forbindelsen");
                    Thread.CurrentThread.Abort();
                }
                    Console.WriteLine("Client > " + sData);
                    Console.WriteLine("Remorte host port: " + endPoint.Port.ToString() + "Local socket port: " + localPoint.Port.ToString());
                    Thread.Sleep(200);
                    lock (laas)
                    {
                        if (beskedTilAlle != string.Empty)
                        {
                            sWriter.WriteLine(beskedTilAlle);
                            sWriter.Flush();
                            beskedTilAlle = string.Empty;
                        }
                        else
                        {
                            sWriter.WriteLine(HighLow(sData, randzom));
                            sWriter.Flush();
                        }
                    }
                
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
