using OpenTK;
using RadicalCore.Gamefiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Resources
{
    public class OBJFile
    {
        public string Name { get; set; }
        public List<OBJMesh> Meshes { get; set; } = new List<OBJMesh>();
        public int TotalVertCount
        {
            get
            {
                int count = 0;
                foreach(var mesh in Meshes)
                {
                    count += mesh.Vertices.Length;
                }
                return count;
            }
        }

        public void Save(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#EXPORTED BY PROTOLUMZ");

            foreach(var mesh in Meshes)
            {
                sb.AppendLine(mesh.ToString());
            }

            File.WriteAllText(path, sb.ToString());
        }

        public void AddMesh(MeshNode mesh)
        {
            OBJMesh objmesh = new OBJMesh();
            objmesh.Name = mesh.Name;
            objmesh.Vertices = mesh.GetVertices().ToArray();
            objmesh.Indicies = mesh.GetIndices().ToArray();
            objmesh.UVS = mesh.GetUVS().ToArray();
            objmesh.ShaderName = mesh.GetShaderName();
            //objmesh.Normals = mesh.GetNormals().ToArray();

            for (int i = 0; i < objmesh.Indicies.Length; i++)
            {
                objmesh.Indicies[i] += TotalVertCount;
            }

            Meshes.Add(objmesh);
        }
    }

    public class OBJMesh
    {
        public string Name { get; set; } = "";
        public Vector3[] Vertices { get; set; } = new Vector3[0];
        public Vector2[] UVS { get; set; } = new Vector2[0];
        public Vector3[] Normals { get; set; } = new Vector3[0];
        public int[] Indicies { get; set; } = new int[0];
        public string ShaderName { get; set; } = "";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("#VERTICES COUNT - " + Vertices.Length.ToString());
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("o " + Name);
            foreach (var vert in Vertices)
            {
                sb.AppendLine("v " + string.Format("{0} {1} {2}", vert.X, vert.Y, vert.Z));
            }

            foreach(var uv in UVS)
            {
                sb.AppendLine("vt " + string.Format("{0} {1}", uv.X, uv.Y));
            }

            foreach (var nrm in Normals)
            {
                sb.AppendLine("HI");
                //sb.AppendLine("vn " + string.Format("{0} {1} {2}", nrm.X, nrm.Y, nrm.Z));
            }

            sb.AppendLine("usemtl " + ShaderName);

            sb.AppendLine("s off");
            string face = " ";
            for (int i = 0; i < Indicies.Length; i++)
            {
                if (i % 3 == 0 && i != 0)
                {
                    face = face.Substring(0, face.Length - 1);
                    sb.AppendLine("f" + face);
                    face = " ";
                }
                var idx = Indicies[i] + 1;
                face += string.Format("{0} ", idx);
            }

            return sb.ToString();
        }
    }

    public class MTLFile
    {
        public List<MTL> Materials { get; set; } = new List<MTL> ();

        public void Save(string path)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("#EXPORTED BY PROTOLUMZ");

            foreach (var mat in Materials)
            {
                sb.AppendLine(mat.ToString());
            }

            File.WriteAllText(path, sb.ToString());
        }

        public void AddMaterial(ShaderNode shader)
        {
            MTL mat = MTL.GetBasic("null");
            mat.Name = shader.Name;
            Materials.Add(mat);
        }
        public void AddMaterial(MTL mat)
        {
            Materials.Add(mat);
        }
    }
    public class MTL
    {
        public string Name { get; set; }
        public float Ns { get; set; }
        public Vector3 Ka { get; set; }
        public Vector3 Kd { get; set; }
        public Vector3 Ks { get; set; }
        public Vector3 Ke { get; set; }
        public float Ni { get; set; }
        public float D { get; set; }
        public int Illum { get; set; }
        public string MapKD { get; set; }

        public static MTL GetBasic(string texturePath)
        {
            MTL mTL = new MTL();
            mTL.Name = "Material";
            mTL.Ns = 0f;
            mTL.Ka = new Vector3(0f);
            mTL.Kd = new Vector3(0f);
            mTL.Ks = new Vector3(0f);
            mTL.Ke = new Vector3(0f);
            mTL.D = 0f;
            mTL.Illum = 1;
            mTL.MapKD = texturePath;
            return mTL;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("newmtl " + Name);
            sb.AppendLine("Ns " + Ns.ToString());
            sb.AppendLine("Ka " + string.Format("{0} {1} {2}", Ka.X, Ka.Y, Ka.Z));
            sb.AppendLine("Kd " + string.Format("{0} {1} {2}", Kd.X, Kd.Y, Kd.Z));
            sb.AppendLine("ks " + string.Format("{0} {1} {2}", Ks.X, Ks.Y, Ks.Z));
            sb.AppendLine("Ke " + string.Format("{0} {1} {2}", Ke.X, Ke.Y, Ke.Z));
            sb.AppendLine("Ni " + Ni.ToString());
            sb.AppendLine("d " + D.ToString());
            sb.AppendLine("Illum " + Illum.ToString());
            sb.AppendLine("map_Kd " + MapKD);

            return sb.ToString();
        }
    }
}
