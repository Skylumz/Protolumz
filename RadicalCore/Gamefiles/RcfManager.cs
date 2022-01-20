using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore.Gamefiles
{
    public class RcfManager
    {
        public List<RcfFile> AllRcfs = new List<RcfFile>();
        public Action<string> UpdateStatus { get; private set; }
        public Action<string> LogError { get; private set; }

        public volatile bool inited = false;

        public void Init(string path, Action<string> us, Action<string> le)
        {
            AllRcfs.Clear();
            UpdateStatus = us;
            LogError = le;

            var files = Directory.GetFiles(path, "*.rcf*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var rcf = new RcfFile(file);
                us("Scanning: " + rcf.Name);
                rcf.Load(us, LogError);
                if(rcf.LastException != null)
                {
                    LogError(rcf.LastException.ToString());
                    continue;
                }
                AllRcfs.Add(rcf);

            }

            //TestP3DS();

            UpdateStatus("Filecache loaded");

            inited = true;         
        }

        public void AddRcfFile(RcfFile rcf)
        {
            AllRcfs.Add(rcf);
        }

        public RcfFile GetRcfFile(string name)
        {
            foreach(var rcf in AllRcfs)
            {
                if (rcf.Name == name)
                {
                    return rcf;
                }
            }
            return null;
        }

        public void TestP3DS()
        {
            foreach(var file in AllRcfs)
            {
                UpdateStatus("Scanning: " + file.Name + "...");

                if (file.Entries == null) continue;
                foreach(var entry in file.Entries)
                {
                    if (entry.Name.EndsWith("rz") || entry.Name.EndsWith("p3d"))
                    {
                        try
                        {
                            UpdateStatus("Scanning: " + entry.Name + " in " + file.Name + "...");
                            var p3d = new P3DFile(entry.Name);
                            p3d.Load(file.GetData(entry));
                        }
                        catch (Exception ex)
                        {
                            LogError("Failure to read: " + entry.Name + " because: " + ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
