using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class TextBibleHolderNode : P3DNode
    {
        public string Language { get; set; }
        public uint Version { get; set; }
        public uint Count { get; set; }
        public List<string> Keys { get; set; }
        public List<uint> StringStarts { get; set; }
        public List<uint> StringStops { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Language = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            Count = dr.ReadUInt32();
            Keys = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                Keys.Add(dr.ReadByteSizedString());
            }
            StringStarts = new List<uint>();
            for (int i = 0; i < Count; i++)
            {
                StringStarts.Add(dr.ReadUInt32());
            }
            StringStops = new List<uint>();
            for (int i = 0; i < Count; i++)
            {
                StringStops.Add(dr.ReadUInt32());
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", Type, Language, Version);
        }
    }
    public class TextBibleStorageNode : P3DNode
    {
        public string Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint TextLength { get; set; }
        public string Text { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            TextLength = dr.ReadUInt32();
            Text = dr.ReadString((int)TextLength);
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Unknown1);
        }
    }
}
