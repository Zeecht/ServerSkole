using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Server_DrawClientProjekt
{
    class Server
    {
        string server;
        int port;
        Thread t;
        List<string> kordinatListe;
        List<string> afsendelser;

        public Server(String server, int port)
        {
            this.server = server;
            this.port = port;
            kordinatListe = new List<string>();
            afsendelser = new List<string>();
        }

        public List<string> KordinatListe { get => kordinatListe; set => kordinatListe = value; }

        public void Connect()
        {
            TcpClient client = new TcpClient(server, port);
            StreamWriter stream = new StreamWriter(client.GetStream());
            
                try
                {
                var v = kordinatListe.ElementAt(0);
                stream.WriteLine(v);
                kordinatListe.RemoveAt(0);
                }
            catch { Exception e; }
            stream.Close();
            client.Close();
        }
    }
}
