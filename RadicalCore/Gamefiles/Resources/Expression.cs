using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class ExpressionNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public uint Count { get; set; }
        public float[] Unknown3 { get; set; }
        public uint[] Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            Count = dr.ReadUInt32();
            Unknown3 = new float[Count];
            for (int i = 0; i < Count; i++)
            {
                Unknown3[i] = dr.ReadSingle();
            }
            Unknown4 = new uint[Count];
            for (int i = 0; i < Count; i++)
            {
                Unknown4[i] = dr.ReadUInt32();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ExpressionGroupNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public string CompositeDrawableName { get; set; }
        public int Count { get; set; }
        public uint[] Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            CompositeDrawableName = dr.ReadByteSizedString();
            Count = dr.ReadInt32();
            Unknown4 = new uint[Count];
            for (int i = 0; i < Count; i++)
            {
                Unknown4[i] = dr.ReadUInt32();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ExpressionMixerNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string Name { get; set; }
        public uint Unknown3 { get; set; }
        public string CompositeDrawableName { get; set; }
        public string ExpressionGroupName { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            Unknown3 = dr.ReadUInt32();
            CompositeDrawableName = dr.ReadByteSizedString();
            ExpressionGroupName = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
}
