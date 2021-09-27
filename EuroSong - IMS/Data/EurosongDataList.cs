using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong.Data
{
    public class EurosongDataList : IEuroSongDatacontext
    {
        List<Song> songslist = new List<Song>();
        public void AddSong(Song song)
        {
            songslist.Add(song);
        }

        public Song GetSong(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return songslist;
        }

        IEnumerable<Song> IEuroSongDatacontext.GetSongs(string word)
        {
            throw new NotImplementedException();
        }
    }
}
