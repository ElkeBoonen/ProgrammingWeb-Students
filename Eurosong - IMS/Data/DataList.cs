using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    public class DataList : IDataContext
    {
        List<Song> _songs = new List<Song>();
        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public Song GetSong(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return _songs;
        }
    }
}
