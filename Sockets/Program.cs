using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sockets
{
    internal class Program
    {
        static void Main(string[] args) => Server();
        public static void Server()
        {
            string street1_of_115547_ind = "бирюлёвская улица", street2_of_115547_ind = "загорьевский проезд", street3_of_115547_ind = "лебедянская улица";
            string street4_of_115547_ind = "михневская улица", street5_of_115547_ind = "михневский проезд";
            string[] streets1 = { street1_of_115547_ind, street2_of_115547_ind, street3_of_115547_ind,
                street4_of_115547_ind, street5_of_115547_ind };
            string street1_of_121170_ind = "улица 1812 года", street2_of_121170_ind = "улица братьев фонченко", street3_of_121170_ind = "улица генерала ермолова";
            string street4_of_121170_ind = "улица дениса давыдова", street5_of_121170_ind = "улица кульнева", street6_of_121170_ind = "кутузовский проезд";
            string street7_of_121170_ind = "кутузовский проспект", street8_of_121170_ind = "площадь победы", street9_of_121170_ind = "поклонная улица";
            string[] streets2 = { street1_of_121170_ind, street2_of_121170_ind, street3_of_121170_ind,
                street4_of_121170_ind, street5_of_121170_ind, street6_of_121170_ind,
                street7_of_121170_ind, street8_of_121170_ind, street9_of_121170_ind };
            string street1_of_125009_ind = "улица большая дмитровка", street2_of_125009_ind = "большая никитская улица", street3_of_125009_ind = "большая садовая улица";
            string street4_of_125009_ind = "большой гнездниковский переулок", street5_of_125009_ind = "большой кисловский переулок", street6_of_125009_ind = "брюсов переулок";
            string street7_of_125009_ind = "газетный переулок", street8_of_125009_ind = "георгиевский переулок", street9_of_125009_ind = "глинищевский переулок";
            string street10_of_125009_ind = "дегтярный переулок", street11_of_125009_ind = "елисеевский переулок", street12_of_125009_ind = "калашный переулок";
            string street13_of_125009_ind = "камергерский переулок", street14_of_125009_ind = "козицкий переулок", street15_of_125009_ind = "копьевский переулок";
            string street16_of_125009_ind = "красная площадь";
            string[] streets3 = { street1_of_125009_ind, street2_of_125009_ind, street3_of_125009_ind,
                street4_of_125009_ind, street5_of_125009_ind, street6_of_125009_ind,
                street7_of_125009_ind, street8_of_125009_ind, street9_of_125009_ind,
                street10_of_125009_ind, street11_of_125009_ind, street12_of_125009_ind,
                street13_of_125009_ind, street14_of_125009_ind, street15_of_125009_ind,
                street16_of_125009_ind };
            string index1 = "115547", index2 = "121170", index3 = "125009";
            string[] indexes = { index1, index2, index3 };
            using (Socket socket1 = new Socket(SocketType.Stream, ProtocolType.IP))
            {
                string serv_name = "192.168.1.130";
                int port = int.Parse("2019");
                IPEndPoint point = new IPEndPoint(Dns.GetHostAddresses(serv_name).Where(addr => addr.AddressFamily == AddressFamily.InterNetwork).First(), port);
                socket1.Connect(point);
                byte[] response = new byte[1024];
                int count = socket1.Receive(response);
                string subscript = Encoding.Default.GetString(response, 0, count);
                Console.WriteLine(subscript);
                socket1.Shutdown(SocketShutdown.Both);
                Socket socket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP), socket3 = socket2.Accept();
                if (subscript == indexes[0]) Streets.Submit(streets1, socket3);
                else if (subscript == indexes[1]) Streets.Submit(streets2, socket3);
                else if (subscript == indexes[2]) Streets.Submit(streets3, socket3);
            }
        }
    }
}