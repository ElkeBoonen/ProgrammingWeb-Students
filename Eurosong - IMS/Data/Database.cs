using Eurosong___IMS.Models;
using LiteDB;
using System.Runtime.Serialization;

namespace Eurosong___IMS.Data
{
    public class Database : IDataContext
    {
        LiteDatabase db = new LiteDatabase("data.db");

        public void AddArtist(Artist artist)
        {
            db.GetCollection<Artist>("Artists").Insert(artist);
        }

        public void AddSong(Song song)
        {
            db.GetCollection<Song>("Songs").Insert(song);
        }

        public Song Delete(int id)
        {
            Song song = GetSong(id);
            db.GetCollection<Song>("Songs").Delete(id);
            return song;
        }

        public Artist GetArtist(int id)
        {
            return db.GetCollection<Artist>("Artists").FindById(id);
        }

        public IEnumerable<Artist> GetArtists()
        {
            return db.GetCollection<Artist>("Artists").FindAll();
        }

        public Song GetSong(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongList(int artist)
        {
            /*List<Song> songs = new List<Song>();
            foreach (Song item in this.GetSongs())
            {
                if (item.Artist == artist) songs.Add(item);
            }
            return songs;*/

            return db.GetCollection<Song>("Songs").FindAll().Where(item => item.Artist == artist);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }
    }
}
