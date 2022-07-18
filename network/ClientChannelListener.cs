using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public class ClientChannelListener : IClientChannelListener
    {
        private String ip;
        private int port;

        private IPEndPoint remoteEndPoint;
        private Socket socket;

        private IPacketManager packetManager;

        public ClientChannelListener(String ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.packetManager = new PacketManager();
        }

        public string GetIp()
        {
            return ip;
        }

        public int GetPort()
        {
            return port;
        }

        public void Start()
        {
            remoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(remoteEndPoint);

            Thread thread = new Thread(ListenPackets);
            thread.Start();
        }

        public void ListenPackets()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    String[] packetString = builder.ToString().Split(';');
                    int packetId = Convert.ToInt32(packetString[0]);
                    IPacketServer packet = (IPacketServer)packetManager.GetPacket(packetId);
                    String str = builder.ToString().Substring(packetString[0].Length + 1);
                    packet.PacketFromString(str);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void SendPacket(IPacketClient packet)
        {
            try
            {
                String str = packetManager.GetPacketId(packet.GetType()) + ";" + packet.PacketToString();
                socket.Send(Encoding.Unicode.GetBytes(str));
            }
            catch (Exception ex) { Console.WriteLine(ex); }
        }

        public void End()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void RegisterPackets()
        {
            packetManager.RegisterPacket(typeof(C0PacketSendPressure));
            packetManager.RegisterPacket(typeof(S0PacketSendResponse));
        }
    }

    internal class PacketManager : IPacketManager
    {
        private List<Type> packets = new List<Type>();

        public IPacket GetPacket(int id)
        {
            Type packetType = packets[id];

            ConstructorInfo constructor = packetType.GetConstructor(new Type[] {});
            return (IPacket)constructor.Invoke(null);
        }

        public int GetPacketId(Type packet)
        {
            for(int i = 0; i < packets.Count; i++)
            {
                if (packets[i] == packet) return i;
            }
            return -1;
        }

        public void RegisterPacket(Type packet)
        {
            packets.Add(packet);
        }
    }
}
