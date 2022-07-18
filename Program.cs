using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class Program
    {
        public static ClientChannelListener listener = new ClientChannelListener("127.0.0.1", 8005);

        public static void Main()
        {
            PressureSensorsController.initializeSensors();
            listener.RegisterPackets();

            listener.Start();

            Console.Write("Введите название датчика давления:");
            string name = Console.ReadLine();

            IPressureSensor sensor = PressureSensorsController.GetSensor(name);
            if (sensor == null)
            {
                Console.WriteLine("Датчика давления с таким названием не существует!");
                listener.End();
                return;
            }

            Console.Write("Введите показания:");
            double pressure = Convert.ToDouble(Console.ReadLine());

            listener.SendPacket(new C0PacketSendPressure(name, sensor.PressureToHexString((float)pressure)));

            Console.Read();
            listener.End();
        }
    }
}
