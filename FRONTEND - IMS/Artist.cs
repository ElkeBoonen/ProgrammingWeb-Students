using System;
using System.Collections.Generic;
using System.Text;

namespace FRONTEND___IMS
{
    class Artist
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{id} - {name}";
        }
    }
}
