using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_DrawServerProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(13000);

            server.Connect();
        }
    }
}
