using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_ConnectTrådetTCP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ClientDemo client = new ClientDemo("127.0.0.1",13000);
        }
    }
}
