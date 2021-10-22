using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong___DSPS.Data
{
    public class EuroSongDataBase : IEuroSongDataContext
    {
        LiteDatabase db = new LiteDatabase("songs.db");
        public void AddSong(Song song)
        {
            db.GetCollection<Song>("Songs").Insert(song);
        }

        public void DeleteSong(int id)
        {
            db.GetCollection<Song>("Songs").Delete(id);
        }

        public Song GetSongById(int id)
        {
            return db.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return db.GetCollection<Song>("Songs").FindAll();
        }

        public IEnumerable<Song> GetSpecificSongs(string word)
        {
            return db.GetCollection<Song>("Songs").Find(item => item.Title.Contains(word) || item.Artist.Contains(word));
        }

        public void UpdateSong(int id, Song song)
        {
            db.GetCollection<Song>("Songs").Update(id, song);
        }
    }
}
