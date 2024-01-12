using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sockets
{
    internal class Streets
    {
        public static void Submit(string[] streets, Socket socket)
        {
            for (int i = 0; i < streets.Length; i++)
            {
                socket.Send(Encoding.Default.GetBytes(streets[i]));
                socket.Shutdown(SocketShutdown.Both);
            }
        }
    }
}