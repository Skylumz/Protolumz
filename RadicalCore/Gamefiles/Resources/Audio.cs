using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class AudioFile
    {
        public uint Unknown1 { get; set; } //always 3
        public uint NameLength { get; set; }
        public string Name { get; set; }
        public uint UnkStr1Length { get; set; }
        public string UnkStr1 { get; set; } // name duplicate??
        public uint Unknown2 { get; set; }
        public uint UnkStr2Length { get; set; } //radp...
        public string UnkStr2 { get; set; }
        public uint UnkStr3Length { get; set; }
        public string UnkStr3 { get; set; }
        public uint Unknown3 { get; set; } //RADP
        public uint Unknown4 { get; set; } //1 usually?
        public uint Unknown5 { get; set; } //48000 usually?
        public uint Unknown6 { get; set; } // 0?
        public uint NodeDataLength { get; set; } //find better name?
        public byte[] NodeData { get; set; }

        public void Read(DataReader dr)
        {

            Unknown2 = dr.ReadUInt32();
            NameLength = dr.ReadUInt32();
            Name = dr.ReadString();
            UnkStr1Length = dr.ReadUInt32();
            UnkStr1 = dr.ReadString();
            Unknown3 = dr.ReadUInt32();
            UnkStr2Length = dr.ReadUInt32();
            UnkStr2 = dr.ReadString();
            UnkStr3Length = dr.ReadUInt32();
            UnkStr3 = dr.ReadString();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            Unknown6 = dr.ReadUInt32();
            NodeDataLength = dr.ReadUInt32();
            NodeData = dr.ReadBytes((int)NodeDataLength);
        }

        public void Write(DataWriter dw)
        {
            throw new NotImplementedException();
        }
    }
    public class BasicSound2File
    {
        public uint Unknown1 { get; set; }
        public uint NameLength { get; set; }
        public string Name { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint StringCount { get; set; }
        public List<uint> StringLengths { get; set; }
        public List<string> Strings { get; set; }
        public uint Unknown6 { get; set; }
        public uint Unknown7 { get; set; }
        public uint Unknown8 { get; set; }
        public uint Unknown9 { get; set; }
        public uint Unknown10 { get; set; }
        public uint Unknown11 { get; set; }
        public uint UnkStr1Length { get; set; }
        public string UnkStr1 { get; set; }
        public uint Unknown12 { get; set; }
        public uint Unknown13 { get; set; }
        public byte Unknown14 { get; set; } // count of filepaths...?
        public uint UnkStr2Length { get; set; }
        public string UnkStr2 { get; set; } // some filepath?
        public byte[] UnkData { get; set; } //80 bytes of something 
        public byte Unknown15 { get; set; } // count of unk str 3...?
        public uint UnkStr3Length { get; set; }
        public string UnkStr3 { get; set; }
        public uint Unknown16 { get; set; }
        public uint Unknown17 { get; set; }
        public byte Unknown18 { get; set; } // count of unk str 4...?
        public uint UnkStr4Length { get; set; }
        public string UnkStr4 { get; set; }

        public void Read(DataReader dr)
        {
            Unknown1 = dr.ReadUInt32();
            NameLength = dr.ReadUInt32();
            Name = dr.ReadString();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            StringCount = dr.ReadUInt32();

            StringLengths = new List<uint>();
            Strings = new List<string>();
            for (int i = 0; i < StringCount; i++)
            {
                StringLengths.Add(dr.ReadUInt32());
                Strings.Add(dr.ReadString());
            }

            Unknown6 = dr.ReadUInt32();
            Unknown7 = dr.ReadUInt32();
            Unknown8 = dr.ReadUInt32();
            Unknown9 = dr.ReadUInt32();
            Unknown10 = dr.ReadUInt32();
            Unknown11 = dr.ReadUInt32();
            UnkStr1Length = dr.ReadUInt32();
            UnkStr1 = dr.ReadString();
            Unknown12 = dr.ReadUInt32();
            Unknown13 = dr.ReadUInt32();
            Unknown14 = dr.ReadByte();
            UnkStr2Length = dr.ReadUInt32();
            UnkStr2 = dr.ReadString();
            UnkData = dr.ReadBytes(80);
            Unknown15 = dr.ReadByte();
            UnkStr3Length = dr.ReadUInt32();
            UnkStr3 = dr.ReadString();
            Unknown16 = dr.ReadUInt32();
            Unknown17 = dr.ReadUInt32();
            Unknown18 = dr.ReadByte();
            UnkStr4Length = dr.ReadUInt32();
            UnkStr4 = dr.ReadString();
        }

        public void Write(DataWriter dr)
        {
            throw new NotImplementedException();
        }
    }
    public class AudioNode : P3DNode
    {
        public uint Unknown1 { get; set; } //always 10
        public uint TypeNameLength { get; set; }
        public string TypeName { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            TypeNameLength = dr.ReadUInt32();
            TypeName = dr.ReadString();

            switch (TypeName)
            {
                case "AudioFile":
                case "BasicSoundII":
                case "PhysicsSound3Voice":
                case "AmbienceSound2":
                case "AmbientVehicleSound":
                case "AudioMemoryBudget":
                case "AudioSoundGroups":
                case "BaseAmbienceSound":
                case "CompLimitSetting":
                case "DialogueSoundGroups":
                case "FrontendSounds":
                case "GasMaskSound":
                case "LairAmbienceSound":
                case "Mixer":
                case "ReverbSetting":
                case "Sequence":
                case "SideChain":
                case "MaterialMap":
                case "DualDistanceSound":
                case "SubsonicSound":
                case "AudioDialogueSubtitle":
                    break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} - @{2} {3} bytes", Type, TypeName, Offset, Size);
        }
    }
}
