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
        public int[] Indicies { get; set; } = new int[0];

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("o " + Name);
            sb.AppendLine("#VERTICES COUNT - " + Vertices.Length.ToString());
            foreach (var vert in Vertices)
            {
                sb.AppendLine("v " + string.Format("{0} {1} {2}", vert.X, vert.Y, vert.Z));
            }
            
            sb.AppendLine("#FACES COUNT - " + (Indicies.Length / 3).ToString());
            sb.AppendLine("s on");
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
}
