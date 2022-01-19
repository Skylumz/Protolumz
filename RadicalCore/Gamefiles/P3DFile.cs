using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace RadicalCore.Gamefiles
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class P3DFile : Gamefile
    {
        public string Name { get; set; }
        public string FilePath { get; set; }

        public uint Magic { get; set; }
        public uint HeaderSize { get; set; }
        public uint FileSize { get; set; }
        public List<P3DNode> Nodes { get; set; }


        public P3DFile(string filepath)
        {
            Name = Path.GetFileName(filepath);
            FilePath = filepath;
        }

        public void Load(byte[] data)
        {
            Read(new DataReader(new MemoryStream(data)));
        }

        public void Read(DataReader dr)
        {
            Magic = dr.ReadUInt32();
            HeaderSize = dr.ReadUInt32();
            FileSize = dr.ReadUInt32();

            if (FileSize > dr.Length)
            {
                throw new Exception("Incorrect stream length.");
            }

            Nodes = new List<P3DNode>();
            while (dr.Position < FileSize)
            {
                var node = P3DNode.ReadNode(dr, null);
                Nodes.Add(node);
            }

            if (dr.Position != FileSize)
            {
                throw new Exception("Incorrect length read.");
            }
        }

        public void Write(DataReader dr)
        {
            throw new NotImplementedException();
        }
    }

    public enum P3DNodeType : uint
    {
        CompositeDrawable = 1191936,
        CompositeDrawablePolySkinReference = 1191937,
        CompositeDrawableExpressionMixerReference = 1191939,

        Skeleton = 143360,
        Billboard = 94214,
        Geometry = 65536,

        Model = 151552,
        Mesh = 151553,
        UnkMeshData1 = 65539,
        UnkMeshData2 = 65540,
        SkinnedMeshBuffers = 151554,
        MeshBuffers = 151555,

        IndexBuffer = 65601,
        VertexBuffer = 65600,
        BufferDescription = 65603,
        BufferData = 65602,

        Shader = 69653,
        ShaderParameterTexture = 69654,
        ShaderParameterFloat = 69655,
        ShaderParameterVector2 = 69656,
        ShaderParameterVector3 = 69657,
        ShaderParameterVector4 = 69658,
        ShaderParameterName = 69667, 
        ShaderParameterUnknown1 = 69661,
        ShaderParameterUnknown2 = 150994954,

        TextBibleHolder = 98818,
        TextBibleStorage = 98817,

        Physics = 117571584,
        Animation = 1183744,
        ParticleSystem = 88192,

        PolySkin = 65537,
        
        TextureSource = 102403,
        Texture = 102400,
        TexturePNG = 102401,
        TextureFont = 139264,
        TextureDDS = 102406,
        TextureGlyphList = 139265,
        TextureData = 102402,

        Camera = 8704,

        ShaderCode = 69644,
        ShaderGlobalVariable = 69645,
        ShaderProgram = 69643,
        ShaderTemplate = 69641,

        U00010020_PrimitiveGroup = 65568,
        
        MetaObjectDefinition = 133169152,
        MetaObjectData = 133169153,
        
        FightDefinition = 536872705,
        FightData = 536872706,

        Expression = 135168,
        ExpressionGroup = 135169,
        ExpressionMixer = 135170,

        Audio_unk1 = 4261412864,
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class P3DNode : GameFileBlock
    {
        public long Offset { get; set; }
        public byte[] Data { get; set; } //for p3d editor
        public Exception LastException { get; set; }

        public P3DNodeType Type { get; set; }
        public uint HeaderSize { get; set; }
        public uint Size { get; set; }

        public P3DFile Owner { get; set; }
        public P3DNode Parent { get; set; }
        public List<P3DNode> Children { get; set; }

        public virtual void Read(DataReader dr)
        {
            Type = (P3DNodeType)dr.ReadUInt32();
            HeaderSize = dr.ReadUInt32();
            Size = dr.ReadUInt32();

            Children = new List<P3DNode>();
        }

        public virtual void Write(DataReader dr)
        {
            throw new NotImplementedException();
        }

        public static P3DNode ReadNode(DataReader dr, P3DNode parent)
        {
            var start = dr.Position;

            var type = (P3DNodeType)dr.ReadUInt32();
            dr.Position -= 4;
            P3DNode node = new P3DNode();
            switch (type)
            {
                case P3DNodeType.Model:
                    node = new ModelNode();
                    break;
                case P3DNodeType.Mesh:
                    node = new MeshNode();
                    break;
                case P3DNodeType.UnkMeshData1:
                    node = new UnkMeshData1Node();
                    break;
                case P3DNodeType.UnkMeshData2:
                    node = new UnkMeshData2Node();
                    break;
                case P3DNodeType.SkinnedMeshBuffers:
                    node = new SkinnedMeshBuffersNode();
                    break;
                case P3DNodeType.MeshBuffers:
                    node = new MeshBuffersNode();
                    break;

                case P3DNodeType.IndexBuffer:
                    node = new IndexBufferNode();
                    break;
                case P3DNodeType.VertexBuffer:
                    node = new VertexBufferNode();
                    break;
                case P3DNodeType.BufferDescription:
                    node = new BufferDescriptionNode();
                    break;
                case P3DNodeType.BufferData:
                    node = new BufferDataNode();
                    break;

                case P3DNodeType.Shader:
                    node = new ShaderNode();
                    break;
                case P3DNodeType.ShaderParameterTexture:
                    node = new ShaderParameterTextureNode();
                    break;
                case P3DNodeType.ShaderParameterFloat:
                    node = new ShaderParameterFloatNode();
                    break;
                case P3DNodeType.ShaderParameterVector2:
                    node = new ShaderParameterVector2Node();
                    break;
                case P3DNodeType.ShaderParameterVector3:
                    node = new ShaderParameterVector3Node();
                    break;
                case P3DNodeType.ShaderParameterVector4:
                    node = new ShaderParameterVector4Node();
                    break;
                case P3DNodeType.ShaderParameterName:
                    node = new ShaderParameterNameNode();
                    break;
                case P3DNodeType.ShaderParameterUnknown1:
                    break;
                case P3DNodeType.ShaderParameterUnknown2:
                    //node = new ShaderParameterUnknown2();
                    break;

                case P3DNodeType.Audio_unk1:
                    node = new AudioNode();
                    break;
                case P3DNodeType.Billboard:
                    node = new BillboardNode();
                    break;
                case P3DNodeType.CompositeDrawable:
                    node = new CompositeDrawableNode();
                    break;
                case P3DNodeType.CompositeDrawablePolySkinReference:
                    node = new CompositeDrawablePolySkinReferenceNode();
                    break;
                case P3DNodeType.Expression:
                    node = new ExpressionNode();
                    break;
                case P3DNodeType.ExpressionGroup:
                    node = new ExpressionGroupNode();
                    break;
                case P3DNodeType.Geometry:
                    node = new GeometryNode();
                    break;
                case P3DNodeType.ParticleSystem:
                    node = new ParticleSystemNode();
                    break;
                case P3DNodeType.TextBibleHolder:
                    node = new TextBibleHolderNode();
                    break;
                case P3DNodeType.Physics:
                    node = new PhysicsNode();
                    break;
                case P3DNodeType.PolySkin:
                    node = new PolySkinNode();
                    break;
                case P3DNodeType.ShaderProgram:
                    node = new ShaderProgramNode();
                    break;
                case P3DNodeType.ShaderTemplate:
                    node = new ShaderTemplateNode();
                    break;
                case P3DNodeType.Skeleton:
                    node = new SkeletonNode();
                    break;
                case P3DNodeType.TextBibleStorage:
                    node = new TextBibleStorageNode();
                    break;
                case P3DNodeType.TextureSource:
                    node = new TextureSourceNode();
                    break;
                case P3DNodeType.Texture:
                    node = new TextureNode();
                    break;
                case P3DNodeType.TexturePNG:
                    node = new TexturePNGNode();
                    break;
                case P3DNodeType.TextureFont:
                    node = new TextureFontNode();
                    break;
                case P3DNodeType.TextureDDS:
                    node = new TextureDDSNode();
                    break;
                case P3DNodeType.Camera:
                    node = new CameraNode();
                    break;
                case P3DNodeType.ShaderCode:
                    node = new ShaderCodeNode();
                    break;
                case P3DNodeType.ShaderGlobalVariable:
                    node = new ShaderGlobalVariableNode();
                    break;
                case P3DNodeType.U00010020_PrimitiveGroup:
                    node = new U00010020_PrimitiveGroupNode();
                    break;
                case P3DNodeType.TextureGlyphList:
                    node = new TextureGlyphListNode();
                    break;
                case P3DNodeType.TextureData:
                    node = new TextureDataNode();
                    break;
                case P3DNodeType.Animation:
                    node = new AnimationNode();
                    break;
                case P3DNodeType.MetaObjectDefinition:
                    node = new MetaObjectDefinitionNode();
                    break;
                case P3DNodeType.MetaObjectData:
                    node = new MetaObjectDataNode();
                    break;
                case P3DNodeType.FightDefinition:
                    node = new FightDefinitionNode();
                    break;
                case P3DNodeType.FightData:
                    node = new FightDataNode();
                    break;
                case P3DNodeType.CompositeDrawableExpressionMixerReference:
                    node = new CompositeDrawableExpressionMixerReferenceNode();
                    break;
                case P3DNodeType.ExpressionMixer:
                    node = new ExpressionMixerNode();
                    break;
            node.Offset = dr.Position;
            }
           
            try
            {
                node.Read(dr);
            }
            catch(Exception ex)
            {
                node.LastException = ex;
            }

            node.Offset = dr.Position;
            dr.Position = start + 12; //skip header data
            node.Data = dr.ReadBytes((int)node.HeaderSize);
            dr.Position = start + node.HeaderSize;

            node.Parent = parent;

            if (dr.Position != start + node.HeaderSize)
            {
                throw new Exception();
            }

            var end = start + node.Size;

            while(dr.Position != end)
            {
                var child = P3DNode.ReadNode(dr, node);
                node.Children.Add(child);
            }

            if (dr.Position != end)
            {
                throw new Exception();
            }

            return node;
        }

        public override string ToString()
        {
            return string.Format("{0} - @{1} {2} bytes", Type, Offset, Size);
        }
    }

    public interface AudioNodeHeader
    {
        void Read(DataReader dr);
        void Write(DataWriter dw);
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AudioFileHeader : AudioNodeHeader
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BasicSound2FileHeader : AudioNodeHeader
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AudioNode : P3DNode
    {
        public uint Unknown1 { get; set; } //always 10
        public uint TypeNameLength { get; set; }
        public string TypeName { get; set; }
        public AudioNodeHeader Header { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            TypeNameLength = dr.ReadUInt32();
            TypeName = dr.ReadString();

            switch (TypeName)
            {
                case "AudioFile":
                    Header = new AudioFileHeader();
                    break;
                case "BasicSoundII":
                    Header = new BasicSound2FileHeader();
                    break;
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
                case "AudioDialogueSubttitle":
                    break;
                default:
                    break;
            }

            if (Header != null)
            {
                Header.Read(dr);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} bytes", TypeName, Offset, Size);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BillboardNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public string NewShaderName { get; set; }
        public uint CutOffEnabled { get; set; }
        public uint ZTest { get; set; }
        public uint ZWrite { get; set; }
        public uint OcclusionCulling { get; set; }
        public uint QuadCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);
            
            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            NewShaderName = dr.ReadByteSizedString();
            CutOffEnabled = dr.ReadUInt32();
            ZTest = dr.ReadUInt32();
            ZWrite = dr.ReadUInt32();
            OcclusionCulling = dr.ReadUInt32();
            QuadCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GeometryNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public uint PrimitiveGroupCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            PrimitiveGroupCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ShaderParameterFloatNode: P3DNode
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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


    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ModelNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string Name { get; set; }
        public string SkeletonName { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            SkeletonName = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MeshNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public string Name { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class UnkMeshData1Node : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint Unknown6 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            Unknown6 = dr.ReadUInt32();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class UnkMeshData2Node : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MeshBuffersNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string ShaderName { get; set; }
        public uint Unknown2 { get; set; }
        public string IndexBufferName { get; set; }
        public string VertexBufferName { get; set; }
        public byte End { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            ShaderName = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            IndexBufferName = dr.ReadByteSizedString();
            VertexBufferName = dr.ReadByteSizedString();
            End = dr.ReadByte();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, VertexBufferName);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SkinnedMeshBuffersNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string ShaderName { get; set; }
        public uint Unknown2 { get; set; }
        public string IndexBufferName { get; set; }
        public string VertexBufferName { get; set; }
        public string SkinnedVertexBufferName { get; set; }
        public byte End { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            ShaderName = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            IndexBufferName = dr.ReadByteSizedString();
            VertexBufferName = dr.ReadByteSizedString();
            SkinnedVertexBufferName = dr.ReadByteSizedString();
            End = dr.ReadByte();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, VertexBufferName);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class IndexBufferNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string Name { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint Unknown6 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            Unknown6 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class VertexBufferNode : P3DNode
    {
        //string is read differently on this one same structure tho...
        public uint Unknown1 { get; set; }
        public string Name { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public uint Unknown6 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            //dr.ReadBytes((int)HeaderSize - 12); //till this name thing is fixed
            //return;

            Unknown1 = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            Unknown6 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BufferElement
    {
        public string Name { get; set; }
        public uint Unk1 { get; set; } // data count?
        public uint Unk2 { get; set; } // data size?
        public uint Unk3 { get; set; }
        public uint Unk4 { get; set; }
        public uint Unk5 { get; set; } // buffer count?
        public uint Unk6 { get; set; }
        public uint Unk7 { get; set; }

        public void Read(DataReader dr)
        {
            Name = dr.ReadByteSizedString();
            Unk1 = dr.ReadUInt32();
            Unk2 = dr.ReadUInt32();
            Unk3 = dr.ReadUInt32();
            Unk4 = dr.ReadUInt32();
            Unk5 = dr.ReadUInt32();
            Unk6 = dr.ReadUInt32();
            Unk7 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return Name;
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BufferDescriptionNode : P3DNode
    {
        public uint ElementCount { get; set; }
        public List<BufferElement> Elements { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            ElementCount = dr.ReadUInt32();
            Elements = new List<BufferElement>();
            for (int i = 0; i < ElementCount; i++)
            {
                var element = new BufferElement();
                element.Read(dr);
                Elements.Add(element);
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} elements", Type, ElementCount);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BufferDataNode : P3DNode
    {
        public int BufferDataLength { get; set; }
        public byte[] BufferData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            BufferDataLength = dr.ReadInt32();
            BufferData = dr.ReadBytes(BufferDataLength);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} bytes", Type, BufferDataLength);
        }
    }



    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CompositeDrawableNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public string SkeletonName { get; set; }
        public uint PrimitivesCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            SkeletonName = dr.ReadByteSizedString();
            PrimitivesCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CompositeDrawablePolySkinReferenceNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public string PolySkinName { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            PolySkinName = dr.ReadByteSizedString();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, PolySkinName);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CompositeDrawableExpressionMixerReferenceNode : P3DNode
    {
        public uint Unknown1 { get; set; }
        public string ExpressionMixerName { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadUInt32();
            ExpressionMixerName = dr.ReadByteSizedString();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, ExpressionMixerName);
        }
    }



    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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




    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ParticleSystemNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public uint Unknown3 { get; set; }
        public uint Unknown4 { get; set; }
        public uint Unknown5 { get; set; }
        public Vector4 Rotation { get; set; }
        public Vector3 Translation { get; set; }
        public uint EmitterCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            Unknown3 = dr.ReadUInt32();
            Unknown4 = dr.ReadUInt32();
            Unknown5 = dr.ReadUInt32();
            Rotation = dr.ReadVector4();
            Translation = dr.ReadVector3();
            EmitterCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextBibleHolderNode : P3DNode
    {
        public uint Count { get; set; }
        public string Language { get; set; }
        public uint Version { get; set; }
        public List<string> Keys { get; set; }
        public List<uint> StringStarts { get; set; }
        public List<uint> StringStops { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextBibleStorageNode : P3DNode
    {
        public string Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint TBDataLength { get; set; }
        public byte[] TBData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Unknown1 = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
            TBDataLength = dr.ReadUInt32();
            TBData = dr.ReadBytes((int)TBDataLength);
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} bytes", Type, TBDataLength);
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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



    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PhysicsNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }


    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AnimationNode : P3DNode
    {
        public uint Version { get; set; }
        public string Name { get; set; }
        public string AnimationType { get; set; } //make a enum???
        public float FrameCount { get; set; }
        public float FrameRate { get; set; }
        public uint Cyclic { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            Name = dr.ReadByteSizedString();
            AnimationType = dr.ReadString(4);
            FrameCount = dr.ReadSingle();
            FrameRate = dr.ReadSingle();
            Cyclic = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SkeletonNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public uint JointCount { get; set; }
        public uint PartitionCount { get; set; }
        public uint BoneCount { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            JointCount = dr.ReadUInt32();
            PartitionCount = dr.ReadUInt32();
            BoneCount = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PolySkinNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }
        public string SkeletonName { get; set; }
        public uint Unknown2 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
            SkeletonName = dr.ReadByteSizedString();
            Unknown2 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }




    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TextureNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Bpp { get; set; }
        public uint AlphaDepth { get; set; }
        public uint MipMapCount { get; set; }
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
            MipMapCount = dr.ReadUInt32();
            TextureType = dr.ReadUInt32();
            Usage = dr.ReadUInt32();
            Priority = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    [TypeConverter(typeof(ExpandableObjectConverter))]
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



    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class CameraNode : P3DNode
    {
        public string Name { get; set; }
        public uint Version { get; set; }
        public float FOV { get; set; }
        public float AspectRatio { get; set; }
        public float NearClip { get; set; }
        public float FarClip { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Look { get; set; }
        public Vector3 Up { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Version = dr.ReadUInt32();
            FOV = dr.ReadSingle();
            AspectRatio = dr.ReadSingle();
            NearClip = dr.ReadSingle();
            FarClip = dr.ReadSingle();
            Position = dr.ReadVector3();
            Look = dr.ReadVector3();
            Up = dr.ReadVector3();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }


    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class U00010020_PrimitiveGroupNode : P3DNode
    {
        public uint Version { get; set; }
        public string ShaderName { get; set; }
        public uint PrimitiveType { get; set; }
        public uint VertexType { get; set; }
        public uint VertexCount { get; set; }
        public uint IndicesCount { get; set; }
        public uint MatrixCount { get; set; } // skeleton bones / blendindices
        public uint MemoryImaged { get; set; }
        public uint Optimized { get; set; }
        public uint VertexAnimated { get; set; }
        public uint VertexAnimationMask { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Version = dr.ReadUInt32();
            ShaderName = dr.ReadByteSizedString();
            PrimitiveType = dr.ReadUInt32();
            VertexType = dr.ReadUInt32();
            VertexCount = dr.ReadUInt32();
            IndicesCount = dr.ReadUInt32();
            MatrixCount = dr.ReadUInt32();
            MemoryImaged = dr.ReadUInt32();
            Optimized = dr.ReadUInt32();
            VertexAnimated = dr.ReadUInt32();
            VertexAnimationMask = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} : {1}, {2} vertex count", Type, ShaderName, VertexCount);
        }
    }


    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MetaObject
    {
        public uint NameLength { get; set; }
        public string Name { get; set; }
        public Vector3 Position { get; set; }
        public Vector4 Rotation { get; set; }
        public Vector3 Scale { get; set; }
        public uint Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint Unknown3 { get; set; }

        public void Read(DataReader dr)
        {
            var start = dr.Position;

            NameLength = dr.ReadUInt32();
            Name = dr.ReadString((int)NameLength);
            Position = dr.ReadVector3();
            Rotation = dr.ReadVector4();
            Scale = dr.ReadVector3();
            Unknown1 = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();

            if (dr.Position != start + Name.Length + 56)
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return string.Format("MetaObject - {0}", Name);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MetaObjectDataNode : P3DNode
    {
        public uint DataLength { get; set; }
        public uint Identifier { get; set; }
        
        public uint MetaObjectCount { get; set; }
        public List<MetaObject> MetaObjects { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            DataLength = dr.ReadUInt32();
            var start = dr.Position;
            Identifier = dr.ReadUInt32();
            
            if (Identifier == 1096041805)
            {
                dr.Position -= 4;
                dr.ReadBytes((int)DataLength);
            }
            else
            {
                MetaObjectCount = dr.ReadUInt32();
                MetaObjects = new List<MetaObject>();
                for (int i = 0; i < MetaObjectCount; i++)
                {
                    MetaObject obj = new MetaObject();
                    obj.Read(dr);
                    MetaObjects.Add(obj);
                }
            }

            if (dr.Position != start + DataLength)
            {
                throw new Exception();
            }
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} bytes", Type, DataLength);
        }
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class MetaObjectDefinitionNode : P3DNode
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public string TypeName { get; set; }
        public ushort Unknown4 { get; set; }
        public ushort Unknown5 { get; set; }
        public uint Unknown6 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            LongName = dr.ReadByteSizedString();
            ShortName = dr.ReadByteSizedString();
            TypeName = dr.ReadByteSizedString();
            Unknown4 = dr.ReadUInt16();
            Unknown5 = dr.ReadUInt16();
            Unknown6 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, ShortName);
        }
    }
    



    [TypeConverter(typeof(ExpandableObjectConverter))]
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
    }
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class FightDataNode : P3DNode
    {
        public int FightDataLength { get; set; }
        public byte[] FightData { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            FightDataLength = dr.ReadInt32();
            FightData = dr.ReadBytes((int)FightDataLength);
        }
    }
}
