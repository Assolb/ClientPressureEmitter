using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class SmallestPressureSensor : IPressureSensor
    {
        private String[] names;

        public SmallestPressureSensor()
        {
            this.names = new String[] { "М121", "М122" };
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
            float modifier = 2621250f;
            localPresssure += (int)(modifier * pressure);
            return Convert.ToString(localPresssure, 16) + "h";
        }
    }
}
