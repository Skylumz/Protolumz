using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace RadicalCore.Gamefiles
{
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

        public VertexBufferNode GetVertexBufferNode(bool data = false)
        {
            foreach (var node in Children)
            {
                if (node.Type == P3DNodeType.SkinnedMeshBuffers)
                {
                    SkinnedMeshBuffersNode meshnode = node as SkinnedMeshBuffersNode;

                    VertexBufferNode vertnode = null;

                    foreach (var cn in Owner.GetAllNodes())
                    {
                        if (cn.Type == P3DNodeType.VertexBuffer)
                        {
                            var n = cn as VertexBufferNode;
                            if (n.Name == ((data) ? meshnode.VertexBufferName : meshnode.SkinnedVertexBufferName))
                            {
                                vertnode = n;
                            }
                        }
                    }
                    return vertnode;
                }
                else if (node.Type == P3DNodeType.MeshBuffers)
                {
                    MeshBuffersNode meshnode = node as MeshBuffersNode;

                    VertexBufferNode vertnode = null;

                    foreach (var cn in Owner.GetAllNodes())
                    {
                        if (cn.Type == P3DNodeType.VertexBuffer)
                        {
                            var n = cn as VertexBufferNode;
                            if (n.Name == meshnode.VertexBufferName)
                            {
                                vertnode = n;
                            }
                        }
                    }
                    return vertnode;
                }
            }
            return null;
        }

        public List<Vector3> GetVertices()
        {
            return GetVertexBufferNode().GetElement("position").Cast<Vector3>().ToList();
        }
        public List<Vector3> GetNormals()
        {
            return GetVertexBufferNode().GetElement("normal").Cast<Vector3>().ToList();
        }
        public List<Vector3> GetTangents()
        {
            return GetVertexBufferNode().GetElement("tangent").Cast<Vector3>().ToList();
        }
        public List<int> GetBoneWeights()
        {
            return GetVertexBufferNode().GetElement("tangent").Cast<int>().ToList();
        }
        public List<int> GetBoneIndices()
        {
            return GetVertexBufferNode().GetElement("indices").Cast<int>().ToList();
        }
        public List<Vector2> GetUVS(string layer = "tex0")
        {
            return GetVertexBufferNode(true).GetElement(layer).Cast<Vector2>().ToList();
        }
        public List<int> GetColors(string layer = "colour0")
        {
            return GetVertexBufferNode(true).GetElement(layer).Cast<int>().ToList();
        }

        public List<int> GetIndices()
        {
            IndexBufferNode indnode = null;

            foreach (var node in Children)
            {
                if (node.Type == P3DNodeType.SkinnedMeshBuffers)
                {
                    SkinnedMeshBuffersNode meshnode = node as SkinnedMeshBuffersNode;

                    foreach (var cn in Owner.GetAllNodes())
                    {
                        if (cn.Type == P3DNodeType.IndexBuffer)
                        {
                            var n = cn as IndexBufferNode;
                            if (n.Name == meshnode.IndexBufferName)
                            {
                                indnode = n;
                            }
                        }
                    }

                    return indnode.GetIndices();
                }
                else if (node.Type == P3DNodeType.MeshBuffers)
                {
                    MeshBuffersNode meshnode = node as MeshBuffersNode;

                    foreach (var cn in Owner.GetAllNodes())
                    {
                        if (cn.Type == P3DNodeType.IndexBuffer)
                        {
                            var n = cn as IndexBufferNode;
                            if (n.Name == meshnode.IndexBufferName)
                            {
                                indnode = n;
                            }
                        }
                    }

                    return indnode.GetIndices();
                }
            }
            return null;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
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

        public List<int> GetIndices()
        {
            BufferDescriptionNode descnode = null;
            foreach (var node in Children)
            {
                if (node.Type == P3DNodeType.BufferDescription)
                {
                    descnode = node as BufferDescriptionNode;
                }
            }

            byte[] bufferdata = null;
            foreach (var node in descnode.Parent.Children)
            {
                if (node.Type == P3DNodeType.BufferData)
                {
                    bufferdata = (node as BufferDataNode).BufferData;
                }
            }

            BufferElement indelem = descnode.Elements[0];

            var indices = new List<int>();
            for (int i = 0; i < indelem.BufferCount; i++)
            {
                var pos = (int)(indelem.TotalSize * i);
                indices.Add(BitConverter.ToInt16(bufferdata, pos));
            }

            return indices;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
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

        public List<object> GetElement(string name)
        {
            BufferDescriptionNode descnode = null;
            foreach (var node in Children)
            {
                if (node.Type == P3DNodeType.BufferDescription)
                {
                    descnode = node as BufferDescriptionNode;
                }
            }

            byte[] bufferdata = null;
            foreach (var node in descnode.Parent.Children)
            {
                if (node.Type == P3DNodeType.BufferData)
                {
                    bufferdata = (node as BufferDataNode).BufferData;
                }
            }

            BufferElement target = null;
            foreach (var element in descnode.Elements)
            {
                if (element.Name == name)
                {
                    target = element;
                }
            }

            if (target == null) return null;

            var elements = new List<object>();

            for (int i = 0; i < target.BufferCount; i++)
            {
                int pos = (int)(target.TotalSize * i) + (int)target.Position;
                if (name.Contains("tex"))
                {
                    var x = BitConverter.ToSingle(bufferdata, pos);
                    var y = BitConverter.ToSingle(bufferdata, pos + 4);
                    elements.Add(new Vector2(x, y));
                }
                else
                {
                    var x = BitConverter.ToSingle(bufferdata, pos);
                    var y = BitConverter.ToSingle(bufferdata, pos + 4);
                    var z = BitConverter.ToSingle(bufferdata, pos + 8);
                    elements.Add(new Vector3(x, y, z));
                }
            }

            return elements;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Type, Name);
        }
    }
    public class BufferElement
    {
        public string Name { get; set; }
        public uint Count { get; set; }
        public uint Size { get; set; }
        public uint Position { get; set; }
        public uint TotalSize { get; set; }
        public uint BufferCount { get; set; }
        public uint Unk6 { get; set; }
        public uint Unk7 { get; set; }

        public void Read(DataReader dr)
        {
            Name = dr.ReadByteSizedString();
            Count = dr.ReadUInt32();
            Position = dr.ReadUInt32();
            Position = dr.ReadUInt32();
            TotalSize = dr.ReadUInt32();
            BufferCount = dr.ReadUInt32();
            Unk6 = dr.ReadUInt32();
            Unk7 = dr.ReadUInt32();
        }

        public override string ToString()
        {
            return Name;
        }
    }
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
}

