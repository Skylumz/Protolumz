using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class FightDefinitionNode : P3DNode
    {
        public string Name { get; set; }
        public ushort Unknown1 { get; set; }
        public string Context { get; set; }
        public uint Unknown2 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt16();
            Context = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", Type, Name, Context);
        }
    }
    public class FightDataNode : P3DNode
    {
        public uint FightDataLength { get; set; }
        public byte[] FightData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            FightDataLength = dr.ReadUInt32();
            FightData = dr.ReadBytes((int)FightDataLength);
        }
    }
}
