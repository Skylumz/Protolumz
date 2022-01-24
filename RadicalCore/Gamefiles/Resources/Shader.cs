using RadicalCore.Resources;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class ShaderNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown2 { get; set; }
        public string ShaderTemplateName { get; set; }
        public uint Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            ShaderTemplateName = dr.ReadByteSizedString();
            Unknown4 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} : {2}", Type, Name, ShaderTemplateName);
        }
    }
    public class ShaderParameterTextureNode : P3DNode
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Value = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterFloatNode : P3DNode
    {
        public string Name { get; set; }
        public float Value { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Value = dr.ReadSingle();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterVector2Node : P3DNode
    {
        public string Name { get; set; }
        public Vector2 Value { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Value = dr.ReadVector2();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterVector3Node : P3DNode
    {
        public string Name { get; set; }
        public Vector3 Value { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Value = dr.ReadVector3();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterVector4Node : P3DNode
    {
        public string Name { get; set; }
        public Vector4 Value { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Value = dr.ReadVector4();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterNameNode : P3DNode
    {
        public string Name { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderParameterUnknown2 : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public string Name { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }

    public enum ShaderProgramType : uint
    {
        VertexShader = 0,
        PixelShader = 1
    }
    public enum ShaderCodeType
    {
        Source = 0,
        Compiled = 5
    }
    public enum ShaderVariableType : uint
    {
        @float = 1,
        float2 = 2,
        float3 = 3,
        float4 = 4,
        float4x4 = 5,
        sampler2D = 6,
        sampler3D = 7,
        samplerCUBE = 8,
        sampler2D_ShadowMap = 9,
        @bool = 10
    }
    public class ShaderProgramNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown02 { get; set; }
        public ShaderProgramType ShaderType { get; set; }
        public uint ChildCount2 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown02 = dr.ReadUInt32();
            ShaderType = (ShaderProgramType)dr.ReadUInt32();
            ChildCount2 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderCodeNode : P3DNode
    {
        public ShaderCodeType CodeType { get; set; }
        public uint ShaderDataLength { get; set; }
        public uint GlobalVariableCount { get; set; }
        public byte[] ShaderData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            CodeType = (ShaderCodeType)dr.ReadUInt32();
            ShaderDataLength = dr.ReadUInt32();
            GlobalVariableCount = dr.ReadUInt32();
            ShaderData = dr.ReadBytes((int)ShaderDataLength);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, CodeType);
        }
    }
    public class ShaderGlobalVariableNode : P3DNode
    {
        public string Name { get; set; }
        public ShaderVariableType VariableType { get; set; }
        public uint Register { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            VariableType = (ShaderVariableType)dr.ReadUInt32();
            Register = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderTemplateNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown02 { get; set; }
        public uint PassCount { get; set; }
        public uint Unknown04 { get; set; }
        public uint Unknown05 { get; set; }
        public uint NumFloat2 { get; set; }
        public uint Unknown07 { get; set; }
        public uint Unknown08 { get; set; }
        public uint Unknown09 { get; set; }
        public uint NumFloat3 { get; set; }
        public uint Unknown11 { get; set; }
        public uint Unknown12 { get; set; }
        public uint NumFloat4 { get; set; }
        public uint NumMatrices { get; set; }
        public uint NumBools { get; set; }
        public uint Unknown16 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown02 = dr.ReadUInt32();
            PassCount = dr.ReadUInt32();
            Unknown04 = dr.ReadUInt32();
            Unknown05 = dr.ReadUInt32();
            NumFloat2 = dr.ReadUInt32();
            Unknown07 = dr.ReadUInt32();
            Unknown08 = dr.ReadUInt32();
            Unknown09 = dr.ReadUInt32();
            NumFloat3 = dr.ReadUInt32();
            Unknown11 = dr.ReadUInt32();
            Unknown12 = dr.ReadUInt32();
            NumFloat4 = dr.ReadUInt32();
            NumMatrices = dr.ReadUInt32();
            NumBools = dr.ReadUInt32();
            Unknown16 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderTemplate_unk1 : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public string UnkStr1 { get; set; }
        public string UnkStr2 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown6 { get; set; }
        public uint Unknown7 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            UnkStr1 = dr.ReadByteSizedString();
            UnkStr2 = dr.ReadByteSizedString();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown6 = dr.ReadUInt32();
            Unknown7 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderTemplate_unk2 : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class ShaderTemplate_unk3 : P3DNode
    {
        public uint Unknown1 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0}", Type);
        }
    }
    public class ShaderTemplate_unk4 : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown7 { get; set; }
        public uint Unknown8 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown7 = dr.ReadUInt32();
            Unknown8 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0}", Type);
        }
    }
    public class ShaderTemplate_unk5 : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown5 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0}", Type);
        }
    }
    public class ShaderTemplate_unk6 : P3DNode
    {
        public uint Unknown1 { get; set; }
        public P3DNodeType PointerType { get; set; } //wierd name but idk
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            PointerType = (P3DNodeType)dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0}", Type);
        }
    }
}
