using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    public interface IDataContext
    {
        void AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Song GetSong(int id);
    }
}
