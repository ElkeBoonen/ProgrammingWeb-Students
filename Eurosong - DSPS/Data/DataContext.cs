using Eurosong___DSPS.Models;

namespace Eurosong___DSPS.Data
{
    public interface DataContext
    {
        void AddSong(Song song);

        void DeleteSong(int id);
        IEnumerable<Song> GetSongs();
        IEnumerable<Song> GetSongsByTitle(string word);
        Song GetSongById(int id);
    }
}
