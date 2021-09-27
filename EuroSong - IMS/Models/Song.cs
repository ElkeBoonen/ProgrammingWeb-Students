using System;

namespace EuroSong
{
    //song model
    public class Song
    {
        public int ID { get; private set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Spotify { get; set; }
    }
}
