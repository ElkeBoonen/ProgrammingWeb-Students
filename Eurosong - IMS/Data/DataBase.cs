using Eurosong___IMS.Models;
using LiteDB;

namespace Eurosong___IMS.Data
{
    public class DataBase : IDataContext
    {
        private LiteDatabase _db = new LiteDatabase("data.db"); 
        private const string _SONGS = "Songs";
        public void AddSong(Song song)
        {
            _db.GetCollection<Song>(_SONGS).Insert(song);
        }
        
        public IEnumerable<Song> GetSongs()
        {
            return _db.GetCollection<Song>(_SONGS).FindAll();
        }

        public IEnumerable<Song> GetSongsByWord(string word)
        {
            return _db.GetCollection<Song>(_SONGS).FindAll().Where(s => s.Title.ToLower().Contains(word.ToLower()));
        }

        public Song GetSongById(int id)
        {
            return _db.GetCollection<Song>(_SONGS).FindById(id);
        }

        public void DeleteSong(int id)
        {
            _db.GetCollection<Song>(_SONGS).Delete(id);
        }
    }
}
