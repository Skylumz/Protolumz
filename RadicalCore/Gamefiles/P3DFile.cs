using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;

namespace RadicalCore.Gamefiles
{
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
                var node = P3DNode.ReadNode(dr, this, null);
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

        public List<P3DNode> GetNodes(P3DNode node)
        {
            var nodes = new List<P3DNode>();
            nodes.Add(node);
            foreach(var cn in node.Children)
            {
                nodes.AddRange(GetNodes(cn));
            }
            return nodes;
        }
        public List<P3DNode> GetAllNodes()
        {
            var nodes = new List<P3DNode>();
            foreach (var node in Nodes)
            {
                nodes.AddRange(GetNodes(node));
            }
            return nodes;
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
        ShaderTemplate_unk1 = 69642,
        ShaderTemplate_unk2 = 69646,
        ShaderTemplate_unk3 = 69717,
        ShaderTemplate_unk4 = 69647,
        ShaderTemplate_unk5 = 69715,
        ShaderTemplate_unk6 = 69718,

        U00010020_PrimitiveGroup = 65568,
        
        MetaObjectDefinition = 133169152,
        MetaObjectData = 133169153,
        
        FightDefinition = 536872705,
        FightData = 536872706,

        Expression = 135168,
        ExpressionGroup = 135169,
        ExpressionMixer = 135170,

        Audio = 4261412864,

        GFX = 98819,
    }

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

        public static P3DNode ReadNode(DataReader dr, P3DFile owner, P3DNode parent)
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

                case P3DNodeType.Audio:
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
                case P3DNodeType.ShaderTemplate_unk1:
                    node = new ShaderTemplate_unk1();
                    break;
                case P3DNodeType.ShaderTemplate_unk2:
                    node = new ShaderTemplate_unk2();
                    break;
                case P3DNodeType.ShaderTemplate_unk3:
                    node = new ShaderTemplate_unk3();
                    break;
                case P3DNodeType.ShaderTemplate_unk4:
                    node = new ShaderTemplate_unk4();
                    break;
                case P3DNodeType.ShaderTemplate_unk5:
                    node = new ShaderTemplate_unk5();
                    break;
                case P3DNodeType.ShaderTemplate_unk6:
                    node = new ShaderTemplate_unk6();
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
                case P3DNodeType.GFX:
                    node = new GFXNode();
                    break;
            }
            
            node.Offset = dr.Position;
            try
            {
                node.Read(dr);
            }
            catch (Exception ex)
            {
                node.LastException = ex;
            }
            node.Owner = owner;
            node.Parent = parent;
            dr.Position = node.Offset;
            node.Data = dr.ReadBytes((int)node.HeaderSize);

            //dr.Position = start + node.HeaderSize;

            if (dr.Position != start + node.HeaderSize)
            {
                throw new Exception();
            }

            var end = start + node.Size;

            while(dr.Position != end)
            {
                var child = P3DNode.ReadNode(dr, owner, node);
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

    public class GFXNode : P3DNode
    {
        public string Name { get; set; }
        public uint Unknown1 { get; set; }

        public override void Read(DataReader dr)
        {
            base.Read(dr);

            Name = dr.ReadByteSizedString();
            Unknown1 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
}
