using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class S0PacketSendResponse : IPacketServer
    {
        public void PacketFromString(string str)
        {
            Console.WriteLine(DateTime.Now.ToShortTimeString() + ": {" + str + "}");
        }
    }
}
