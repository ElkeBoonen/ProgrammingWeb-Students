using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    public class DataList : IDataContext
    {
        List<Song> list = new List<Song>();
        public void AddSong(Song song)
        {
            list.Add(song);
        }

        public IEnumerable<Song> GetSongs()
        {
            return list;
        }
    }
}
