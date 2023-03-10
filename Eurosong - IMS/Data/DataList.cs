using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    //deze mag verwijderd worden, ik laat die staan ter informatie
    public class DataList : IDataContext
    {
        List<Song> list = new List<Song>();
        public void AddSong(Song song)
        {
            list.Add(song);
        }

        public Song GetSongById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return list;
        }

        public IEnumerable<Song> GetSongsByWord(string word)
        {
            return list.Where(s => s.Title.Contains(word));
        }
    }
}
