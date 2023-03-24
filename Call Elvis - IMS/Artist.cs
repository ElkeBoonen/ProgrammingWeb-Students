using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Elvis___IMS
{
    internal class Artist
    {
        public int id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $"{id} - {name}";
        }
    }
}
