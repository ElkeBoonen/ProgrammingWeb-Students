using Eurosong___DSPS.Models;
using LiteDB;

namespace Eurosong___DSPS.Data
{
    public class DataBase : DataContext
    {
        LiteDatabase db = new LiteDatabase("data.db");

        const string songs = "Songs";
        public void AddSong(Song song)
        {
            db.GetCollection<Song>(songs).Insert(song);
        }
        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>(songs).FindAll();
        }

        public IEnumerable<Song> GetSongsByTitle(string word)
        {
            return db.GetCollection<Song>(songs).FindAll().Where(s => s.Title.Contains(word));
        }
    }
}
