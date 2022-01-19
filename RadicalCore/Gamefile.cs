using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore
{
    public interface Gamefile
    {
        void Read(DataReader dr);
        void Write(DataReader dr);
    }

    public interface GameFileBlock
    {
        void Read(DataReader dr);
        void Write(DataReader dr);
    }
}
