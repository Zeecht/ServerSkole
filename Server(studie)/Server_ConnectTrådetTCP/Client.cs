using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server_ConnectTrådetTCP
{
    class ClientDemo
    {
        private TcpClient _client;

        private StreamReader _sReader;
        private StreamWriter _sWriter;

        private Boolean _isConnected;



        public ClientDemo(string ipAddress, int portNum)
        {
            _client = new TcpClient();
            _client.Connect(IPAddress.Parse(ipAddress), portNum);
            HandleCommunication();
        }

        public void HandleCommunication()
        {
            NetworkStream ns = _client.GetStream();
            _sReader = new StreamReader(ns, Encoding.UTF8);
            _sWriter = new StreamWriter(ns, Encoding.UTF8);
            String sData = null;
            String sDataIncomming = string.Empty;
            _isConnected = true;
        
            while (_isConnected)
            {
                Console.Write("Gæt -> ");
                sData = Console.ReadLine();
                // write data and make sure to flush, or the buffer will continue to 
                // grow, and your data might not be sent when you want it, and will
                // only be sent once the buffer is filled.
                _sWriter.WriteLine(sData);
                try 
                { 
                    _sWriter.Flush();
                    // if you want to receive anything
                    sDataIncomming = _sReader.ReadLine();

                }
                catch (IOException e)
                {
                    Console.WriteLine("Serveren er lukket ned");
                    Console.ReadLine();
                    Thread.CurrentThread.Abort();
                }
                if (sDataIncomming != string.Empty)
                    Console.WriteLine(sDataIncomming);
            }
        }
    }


}
