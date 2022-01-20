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
