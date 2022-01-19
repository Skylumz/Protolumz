using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadicalCore
{
    public static class HashUtil
    {
        public static Dictionary<uint, string> KnownFileNameHashes;
        public static volatile bool inited = false;

        public static void BuildHashDictionary()
        {
            if (KnownFileNameHashes != null) return;
            KnownFileNameHashes = new Dictionary<uint, string>();
            var lines = File.ReadAllLines("hashes.txt");
            foreach(var line in lines)
            {
                if(string.IsNullOrEmpty(line)) continue;
                var kv = line.Split('=');
                var key = uint.Parse(kv[0].Trim());
                var value = kv[1].Trim();
                KnownFileNameHashes.Add(key, value);
            }

            inited = true;
        }

        public static string GetString(uint hash)
        {
            if (KnownFileNameHashes == null) return "";
            string result = "";
            if (KnownFileNameHashes.ContainsKey(hash))
            {
                result = KnownFileNameHashes[hash];
            }
            return result;
        }

        public static uint HashString(string str, uint seed)
        {
            if (str.StartsWith(@"\") == true)
            {
                str = str.Substring(1);
            }

            foreach (var t in Encoding.ASCII.GetBytes(str))
            {
                seed = (seed << 5) - seed;

                if (t < 0x61)
                {
                    seed += (uint)(0x20 + t);
                }
                else
                {
                    seed += t;
                }
            }

            return seed;
        }
    }
}
