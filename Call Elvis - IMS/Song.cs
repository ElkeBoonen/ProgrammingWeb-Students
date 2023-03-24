using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Elvis___IMS
{
    internal class Song
    {
        /*  "id": 5,
            "title": "Rebirth",
            "artist": 11,
            "spotify": "string"*/

        public int id { get; set; }
        public string title { get; set; }
        public int artist { get; set; }
        public string spotify { get; set; }

        public override string ToString()
        {
            return $"{id} - {title} - {artist} - {spotify}";
        }
    }
}
