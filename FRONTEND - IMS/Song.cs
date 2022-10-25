using System;
using System.Collections.Generic;
using System.Text;

namespace FRONTEND___IMS
{
    class Song
    {
        public int id { get; set; }
        public string title { get; set; }
        public int artist { get; set; }
        public string spotify { get; set; }

        public override string ToString()
        {
            return $"{id} - {title} - {artist}\n --> op spotify te vinden: {spotify}";
        }

    }
}
