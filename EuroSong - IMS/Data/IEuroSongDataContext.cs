using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong.Data
{
    public interface IEuroSongDatacontext
    {
        void AddSong(Song song);
        void DeleteSong(int id);
        void UpdateSong(int id, Song song);
        IEnumerable<Song> GetSongs();
        Song GetSong(int id);
        IEnumerable<Song> GetSongs(string word);
    }
}
