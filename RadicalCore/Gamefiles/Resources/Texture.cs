using OpenTK;
using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class TextureSourceNode : P3DNode
    {
        public string FileName { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            FileName = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, FileName);
        }
    }
    public class TextureNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Bpp { get; set; }
        public uint AlphaDepth { get; set; }
        public uint Levels { get; set; }
        public uint TextureType { get; set; }
        public uint Usage { get; set; }
        public uint Priority { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            Width = dr.ReadUInt32();
            Height = dr.ReadUInt32();
            Bpp = dr.ReadUInt32();
            AlphaDepth = dr.ReadUInt32();
            Levels = dr.ReadUInt32();
            TextureType = dr.ReadUInt32();
            Usage = dr.ReadUInt32();
            Priority = dr.ReadUInt32();
        }

        public byte[] GetTextureData()
        {
            foreach(var n in Owner.GetNodes(this))
            {
                if (n is TextureDataNode)
                {
                    return (n as TextureDataNode).TextureData;
                }
            }
            return null;
        }

        public DDSFormat GetFormat()
        {
            foreach (var n in Owner.GetNodes(this))
            {
                if (n is TextureDDSNode)
                {
                    return (n as TextureDDSNode).Format;
                }
            }
            return DDSFormat.Unknown;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class TexturePNGNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Bpp { get; set; }
        public uint Palettized { get; set; }
        public uint HasAlpha { get; set; }
        public uint Format { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
            Width = dr.ReadUInt32();
            Height = dr.ReadUInt32();
            Bpp = dr.ReadUInt32();
            Palettized = dr.ReadUInt32();
            HasAlpha = dr.ReadUInt32();
            Format = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class TextureFontNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public string ShaderName { get; set; }
        public float FontSize { get; set; }
        public float FontWidth { get; set; }
        public float FontHeight { get; set; }
        public float FontBaseLine { get; set; }
        public uint TextureCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            ShaderName = dr.ReadByteSizedString();
            FontSize = dr.ReadSingle();
            FontWidth = dr.ReadSingle();
            FontHeight = dr.ReadSingle();
            FontBaseLine = dr.ReadSingle();
            TextureCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public enum DDSFormat : uint
    {
        Unknown = 0,
        DXT1 = 0x31545844,
        DXT3 = 0x33545844,
        DXT5 = 0x35545844,
    }
    public class TextureDDSNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint MipMapCount { get; set; }
        public DDSFormat Format { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            Width = dr.ReadUInt32();
            Height = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            MipMapCount = dr.ReadUInt32();
            Format = (DDSFormat)dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class TextureGlyphListNode : P3DNode
    {
        public uint TextureNum { get; set; }
        public Vector2 BottomLeft { get; set; }
        public Vector2 TopRight { get; set; }
        public float LeftBearing { get; set; }
        public float RightBearing { get; set; }
        public float Width { get; set; }
        public float Advance { get; set; }
        public uint Code { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            TextureNum = dr.ReadUInt32();
            BottomLeft = dr.ReadVector2();
            TopRight = dr.ReadVector2();
            LeftBearing = dr.ReadSingle();
            RightBearing = dr.ReadSingle();
            Width = dr.ReadSingle();
            Advance = dr.ReadSingle();
            Code = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", Type, TextureNum, Code);
        }
    }
    public class TextureDataNode : P3DNode
    {
        public int TextureDataLength { get; set; }
        public byte[] TextureData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            TextureDataLength = dr.ReadInt32();
            TextureData = dr.ReadBytes(TextureDataLength);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} bytes", Type, TextureDataLength);
        }
    }
}
