using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public interface IPressureSensor
    {
        public String[] GetSensorsNames();

        public String PressureToHexString(float pressure);
    }
}
