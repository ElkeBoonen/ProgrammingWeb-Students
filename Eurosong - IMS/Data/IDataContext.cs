using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    public interface IDataContext
    {
        public void AddSong(Song song);
        public IEnumerable<Song> GetSongs();
        public IEnumerable<Song> GetSongsByWord(string word);
    }
}
