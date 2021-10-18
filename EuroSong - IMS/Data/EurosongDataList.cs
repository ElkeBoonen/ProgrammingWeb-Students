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

        public void DeleteSong(int id)
        {
            throw new NotImplementedException();
        }

        public Song GetSong(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return songslist;
        }

        public void UpdateSong(int id, Song song)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Song> IEuroSongDatacontext.GetSongs(string word)
        {
            throw new NotImplementedException();
        }
    }
}
