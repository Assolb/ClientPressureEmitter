using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class MediumPressureSensor : IPressureSensor
    {
        private String[] names;

        public MediumPressureSensor()
        {
            this.names = new String[] { "К630-1", "К630-2", "К630-3", "К660-1", "К660-2", "К660-3"};
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
            float modifier = 10485.5f;
            localPresssure += (int)(modifier * pressure);
            return Convert.ToString(localPresssure, 16) + "h";
        }
    }
}
