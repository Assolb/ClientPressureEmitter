using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class SmallPressureSensor : IPressureSensor
    {
        private String[] names;

        public SmallPressureSensor()
        {
            this.names = new String[] { 
                "А100", "А200", "В160-1", "В160-2", "В160-3", "В260-1", "В260-2", 
                "В260-3", "К620-1", "К620-2", "К620-3", "К650-1", "К650-2", "К650-3" 
            };
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
            float modifier = 167770f;
            localPresssure += (int)(modifier * pressure);
            return Convert.ToString(localPresssure, 16) + "h";
        }
    }
}
