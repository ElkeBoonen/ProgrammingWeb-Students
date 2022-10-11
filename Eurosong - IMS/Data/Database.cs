using Eurosong___IMS.Models;
using LiteDB;

namespace Eurosong___IMS.Data
{
    public class Database : IDataContext
    {
        LiteDatabase db = new LiteDatabase("data.db");
        public void AddSong(Song song)
        {
            db.GetCollection<Song>("Songs").Insert(song);
        }

        public Song GetSong(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }
    }
}
