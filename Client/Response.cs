using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Client
{
    internal class Response
    {
        public static void Answer(Socket socket, byte[] response, ListBox list_box,
            List<string> places, TextBox box)
        {
            int count = socket.Receive(response);
            places.Add(Encoding.Default.GetString(response, 0, count));
            for (int i = 0; i < places.Count; i++) list_box.Items.Add(places[i]);
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}