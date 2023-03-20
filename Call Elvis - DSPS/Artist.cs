using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Elvis___DSPS
{
    internal class Artist
    {
        /*
            "id": 0,
            "name": "string"
         */

        public int id { get; set; }
        public string name { get; set; }
        public override string ToString()
        {
            return $"{id} - {name}";
        }
    }
}
