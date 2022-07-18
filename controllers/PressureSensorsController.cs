using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class PressureSensorsController
    {
        private static List<IPressureSensor> pressureSensors = new List<IPressureSensor>();

        public static IPressureSensor GetSensor(String name)
        {
            foreach(IPressureSensor pressureSensor in pressureSensors)
            {
                foreach(String s in pressureSensor.GetSensorsNames())
                {
                    if (s == name) return pressureSensor;
                }
            }
            return null;
        }

        public static void initializeSensors()
        {
            pressureSensors.Add(new BigPressureSensor());
            pressureSensors.Add(new MediumPressureSensor());
            pressureSensors.Add(new SmallPressureSensor());
            pressureSensors.Add(new SmallestPressureSensor());
        }
    }
}
