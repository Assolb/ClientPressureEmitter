using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public interface IClientChannelListener
    {
        String GetIp();

        int GetPort();

        void RegisterPackets();

        void Start();

        void ListenPackets();

        void SendPacket(IPacketClient packet);

        void End();
    }
}
