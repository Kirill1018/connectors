using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Client
{
    internal class Check_in
    {
        public static void Register(TextBox box, ListBox list_box, List<string> places,
            string[] indexes)
        {
            Socket socket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket1.Bind(new IPEndPoint(new IPAddress(new byte[] { 192, 168, 1,
                130 }), 2019));
            socket1.Listen(5);
            Socket socket2 = socket1.Accept();
            socket2.Send(Encoding.Default.GetBytes(box.Text));
            socket2.Shutdown(SocketShutdown.Both);
            using (Socket socket3 = new Socket(SocketType.Stream, ProtocolType.IP))
            {
                string serv_name = "192.168.1.130";
                int port = int.Parse("2019");
                IPEndPoint point = new IPEndPoint(Dns.GetHostAddresses(serv_name).Where(addr => addr.AddressFamily == AddressFamily.InterNetwork).First(), port);
                socket3.Connect(point);
                byte[] response = new byte[1024];
                Response.Answer(socket3, response, list_box,
                    places, box);
                socket3.Shutdown(SocketShutdown.Both);
            }
        }
    }
}