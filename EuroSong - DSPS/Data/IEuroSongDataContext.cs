using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong___DSPS.Data
{
    public interface IEuroSongDataContext
    {
        void AddSong(Song song);
        void DeleteSong(int id);
        void UpdateSong(int id, Song song);
        IEnumerable<Song> GetSongs();

        IEnumerable<Song> GetSpecificSongs(string word);
        Song GetSongById(int id);
    }
}
