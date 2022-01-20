using RadicalCore.Resources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace RadicalCore.Gamefiles
{
    public class RcfFile : Gamefile
    {
        //structure data
        public string Magic { get; set; }
        public byte MajorVersion { get; set; }
        public byte MinorVersion { get; set; }
        public Endianess Endian { get; set; }
        public byte Unknown1 { get; set; }
        public uint EntriesPointer { get; set; }
        public uint EntriesSize { get; set; }
        public uint NameTablePointer { get; set; }
        public uint NameTableSize { get; set; }
        public uint Unknown2 { get; set; }
        public uint EntriesCount { get; set; }
        public uint NameAlignment { get; set; }
        public uint Unknown3 { get; set; }
        public List<RcfEntry> Entries { get; set; }
        public List<RcfNameTable> NameTables { get; set; }

        //reference data
        public string Name { get; set; }
        public string FilePath { get; set; }
        public RcfDirectory RootDirectory { get; set; }
        public Exception LastException { get; set; }

        public RcfFile(string filepath)
        {
            Name = Path.GetFileName(filepath);
            FilePath = filepath;
        }

        public void Load(Action<string> UpdateStatus, Action<string> LogError)
        {
            try
            {
                var fs = new FileStream(FilePath, FileMode.OpenOrCreate);
                Read(new DataReader(fs));
                fs.Close();

                //assign entries names from name table
                UpdateStatus("Assigning name tables to " + Name + "...");

                var hashedNameTables = NameTables.ToDictionary(x => HashUtil.HashString(x.Name, 0));
                foreach (var entry in Entries)
                {
                    if (hashedNameTables.TryGetValue(entry.NameHash, out var nameTable))
                    {
                        entry.NameTable = nameTable;
                    }
                    else
                    {
                        throw new Exception("Didn't find name table for entry.");
                    }
                }

                UpdateStatus("Building directory tree for " + Name + "...");

                BuildDirectoryTree();

                //StringBuilder sb = new StringBuilder();
                //foreach(var entry in Entries)
                //{
                //    sb.AppendLine(string.Format("{0} = {1}", entry.NameHash, entry.FullName));
                //}
                //if (File.Exists("hashes.txt"))
                //{
                //    sb.AppendLine(File.ReadAllText("hashes.txt"));
                //}
                //File.WriteAllText("hashes.txt", sb.ToString());

                UpdateStatus("Finished Scanning: " + Name);
            }
            catch (Exception ex)
            {
                LogError("Error reading: " + Name + " because: " + ex.ToString());
                LastException = ex;
            }
        }

        public void Read(DataReader dr)
        {
            Magic = dr.ReadString();
            dr.ReadBytes(8); //padding
            MajorVersion = dr.ReadByte();
            MinorVersion = dr.ReadByte();
            Endian = dr.ReadByte() == 0 ? Endianess.LittleEndian : Endianess.BigEndian;
            Unknown1 = dr.ReadByte();

            if (MajorVersion != 2 || MinorVersion != 1 || Unknown1 != 1)
            {
                throw new FormatException("Bad Rcf Version");
            }

            //swap datareaders endianess
            dr.Endianess = Endian;

            EntriesPointer = dr.ReadUInt32();
            EntriesSize = dr.ReadUInt32();
            NameTablePointer = dr.ReadUInt32();
            NameTableSize = dr.ReadUInt32();
            Unknown2 = dr.ReadUInt32();
            EntriesCount = dr.ReadUInt32();

            //read entries
            dr.Position = EntriesPointer;
            Entries = new List<RcfEntry>();
            for (int i = 0; i < EntriesCount; i++)
            {
                var entry = new RcfEntry(this);
                entry.Read(dr);
                Entries.Add(entry);
            }

            //read name table
            dr.Position = NameTablePointer;
            NameAlignment = dr.ReadUInt32();
            Unknown3 = dr.ReadUInt32();
            NameTables = new List<RcfNameTable>();
            for (int i = 0; i < EntriesCount; i++)
            {
                var nameTable = new RcfNameTable();
                nameTable.Read(dr);
                NameTables.Add(nameTable);
            }
        }

        public void Write(DataReader dr)
        {
            throw new NotImplementedException();
        }

        public byte[] GetData(RcfEntry entry, bool uncompressed = true)
        {
            if (entry.Data != null && entry.Data.Length > 0)
            {
                return entry.Data;
            }

            DataReader dr = new DataReader(new MemoryStream(File.ReadAllBytes(FilePath)));
            dr.Position = entry.DataPointer;

            byte[] data;
            dr.Endianess = Endianess.BigEndian;
            var magic = dr.ReadUInt32();
            dr.Endianess = Endianess.LittleEndian;
            if (magic != 0x525A0000 || !uncompressed) //rz magic
            {
                dr.Position -= 4;
                data = dr.ReadBytes((int)entry.Size);
            }
            else
            {
                var unk1 = dr.ReadUInt32();
                var realSize = dr.ReadInt32();
                var unk2 = dr.ReadUInt32();

                if (unk1 != 0 || unk2 != 0) { throw new FormatException(); }

                var zlib = new InflaterInputStream(dr.baseStream);
                var mstream = new MemoryStream();
                zlib.CopyTo(mstream, realSize);
                data = mstream.ToArray();
            }

            entry.Data = data;
            return data;
        }

        private void BuildDirectoryTree()
        {
            var paths = new List<string>();

            foreach (var nt in NameTables)
            {
                var path = Path.GetDirectoryName(nt.Name);
                if (!paths.Contains(path))
                {
                    paths.Add(path);
                }
            }

            RootDirectory = new RcfDirectory(this, Name);
            var alldirectories = new List<RcfDirectory>() { RootDirectory };
            foreach (var path in paths)
            {
                RcfDirectory current = RootDirectory;
                foreach (var name in path.Split('\\'))
                {
                    bool found = false;
                    foreach (var dir in current.Directories)
                    {
                        if (dir.Name == name)
                        {
                            current = dir;
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        var dir = new RcfDirectory(this, name);
                        alldirectories.Add(dir);
                        if (current != RootDirectory)
                        {
                            dir.Parent = current;
                        }
                        current.Directories.Add(dir);
                        current = dir;
                    }
                }
            }

            var directories = alldirectories.ToDictionary(d => d.FullName);

            foreach (var entry in Entries)
            {
                if (directories.TryGetValue(Path.GetDirectoryName(entry.FullName), out var directory))
                {
                    entry.Directory = directory;
                    directory.Files.Add(entry);
                }
            }
        }
    }

    public class RcfEntry
    {
        //structure data
        public uint NameHash { get; set; }
        public uint DataPointer { get; set; }
        public uint Size { get; set; }

        //reference data
        public string Name { get { return (NameTable != null) ? Path.GetFileName(NameTable.Name) : ""; } }
        public string FullName { get { return (NameTable != null) ? NameTable.Name : ""; } }
        public byte[] Data { get; set; }
        public RcfFile Owner { get; set; }
        public RcfDirectory Directory { get; set; }
        public RcfNameTable NameTable { get; set; }

        public RcfEntry(RcfFile owner)
        {
            Owner = owner;
        }

        public void Read(DataReader dr)
        {
            NameHash = dr.ReadUInt32();
            DataPointer = dr.ReadUInt32();
            Size = dr.ReadUInt32();

            ////read data
            //var savedPosition = dr.Position;
            //dr.Position = DataPointer;
            //Data = dr.ReadBytes((int)Size);
            //dr.Position = savedPosition;
        }

        public void Write(DataReader dr)
        {
            throw new NotImplementedException();
        }
    }

    public class RcfNameTable
    {
        //structure data
        public uint TypeHash { get; set; }
        public uint Alignment { get; set; }
        public uint Unknown1 { get; set; }
        public uint NameSize { get; set; }
        public string Name { get; set; }
        public byte[] Unknown2 { get; set; }

        public bool found = false;

        public void Read(DataReader dr)
        {
            TypeHash = dr.ReadUInt32();
            Alignment = dr.ReadUInt32();
            Unknown1 = dr.ReadUInt32();
            NameSize = dr.ReadUInt32();
            if (NameSize > 0)
            {
                Name = dr.ReadString();
            }
            Unknown2 = dr.ReadBytes(3);
        }

        public void Write(DataReader dr)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Name;
        }
    }

    //not in file for explorer
    public class RcfDirectory
    {
        public string Name { get; set; }
        public string FullName
        {
            get
            {
                var p = Parent;
                var path = new List<string>();
                path.Add(Name);
                while (p != null)
                {
                    path.Add(p.Name);
                    p = p.Parent;
                }
                path.Reverse();
                return string.Join("\\", path);
            }
        }
        public string FullNameWithOwner
        {
            get
            {
                return Owner.FilePath + "\\" + FullName;
            }
        }

        public RcfFile Owner { get; set; }
        public List<RcfEntry> Files { get; set; }
        public List<RcfDirectory> Directories { get; set; }
        public RcfDirectory Parent { get; set; }

        public RcfDirectory(RcfFile owner) 
        {
            Owner = owner;
        }
        public RcfDirectory(RcfFile owner, string name)
        {
            Owner = owner;
            Name = name;
            Directories = new List<RcfDirectory>();
            Files = new List<RcfEntry>();   
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
