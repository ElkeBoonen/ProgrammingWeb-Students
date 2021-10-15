using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong___DSPS.Data
{
    public class EuroSongDataList : IEuroSongDataContext
    {
        List<Song> songs = new List<Song>();
        public void AddSong(Song song)
        {
            songs.Add(song);
        }

        public void DeleteSong(int id)
        {
            throw new NotImplementedException();
        }

        public Song GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return songs;
        }

        public IEnumerable<Song> GetSpecificSongs(string word)
        {
            return songs.Where(item => item.Title.Contains(word) || item.Artist.Contains(word));
        }
    }
}
