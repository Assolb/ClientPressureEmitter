using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class BigPressureSensor : IPressureSensor
    {
        private String[] names;

        public BigPressureSensor()
        {
            this.names = new String[] { "М200-1", "М200-2", "М200-3", "М400-1", "М400-2", "М400-3", "М157" };
        }

        public string[] GetSensorsNames()
        {
            return names;
        }

        public string PressureToHexString(float pressure)
        {
            if (pressure < 0)
            {
                Console.WriteLine("Pressure must to be more than 0");
                return null;
            }
            int localPresssure = 10486;
            float modifier = 1677.6f;
            localPresssure += (int)(modifier * pressure);
            return Convert.ToString(localPresssure, 16) + "h";
        }
    }
}
