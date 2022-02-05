using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RadicalCore.Gamefiles
{
    public class RcfManager
    {
        public List<RcfFile> AllRcfs = new List<RcfFile>();
        public Dictionary<string, P3DFile> AllP3ds = new Dictionary<string, P3DFile>();
        public Action<string> Log { get; private set; }

        public void Init(string path, Action<string> log)
        {
            AllRcfs.Clear();
            Log = log;

            var files = Directory.GetFiles(path, "*.rcf*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var rcf = new RcfFile(file);
                Log("Scanning: " + rcf.Name);
                rcf.Load(Log);
                if(rcf.LastException != null)
                {
                    Log(rcf.LastException.ToString());
                    continue;
                }
                AllRcfs.Add(rcf);

                foreach(var entry in rcf.Entries)
                {
                    if (entry.FullName.EndsWith(".p3d"))
                    {
                        //var p3d = new P3DFile(entry.FullName);
                        //var watch = new Stopwatch();
                        //watch.Start();
                        //var data = rcf.GetData(entry);
                        //watch.Stop();
                        //AllP3ds.Add(entry.FullName, p3d);
                        //UpdateStatus(p3d.Name + " loaded");
                        //LogError(string.Format("Getting data for {0} took {1} seconds", entry.Name, watch.ElapsedMilliseconds * 1000));

                        //Task.Run(() =>
                        //{
                        //    watch.Restart();
                        //    p3d.Load(data);
                        //    watch.Stop();
                        //    LogError(string.Format("Loading {0} took {1} seconds", entry.Name, watch.ElapsedMilliseconds * 1000));
                        //});
                    }
                }
            }

            //TestP3DS();

            Log("Filecache loaded");
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
            StringBuilder sb = new StringBuilder();

            foreach(var file in AllRcfs)
            {
                Log("Scanning: " + file.Name + "...");

                if (file.Entries == null) continue;
                foreach(var entry in file.Entries)
                {
                    if (entry.Name.EndsWith("rz") || entry.Name.EndsWith("p3d"))
                    {
                        try
                        {
                            Log("Scanning: " + entry.Name + " in " + file.Name + "...");
                            var p3d = new P3DFile(entry.Name);
                            p3d.Load(file.GetData(entry));

                            foreach(var node in p3d.GetAllNodes())
                            {
                                if (!Enum.IsDefined(typeof(P3DNodeType), node.Type))
                                {
                                    //sb.AppendLine(p3d.Name + " " + node.Type);
                                    Log(p3d.Name + " " + node.Type);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log("Failure to read: " + entry.Name + " because: " + ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
