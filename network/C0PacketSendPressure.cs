using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class C0PacketSendPressure : IPacketClient
    {
        private String sensor, pressure;

        public C0PacketSendPressure(String sensor, String pressure)
        {
            this.sensor = sensor;
            this.pressure = pressure;
        }

        public String PacketToString()
        {
            return sensor + ";" + pressure;
        }
    }
}
