using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProgram
{
    public interface IPacketManager
    {
        void RegisterPacket(Type packet);

        IPacket GetPacket(int id);

        int GetPacketId(Type packet);
    }
}
