using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong.Data
{
    public class EurosongDataBase : IEuroSongDatacontext
    {
        LiteDatabase database = new LiteDatabase(@"data.db");

        public void AddSong(Song song)
        {
            database.GetCollection<Song>("Songs").Insert(song);
        }

        public void DeleteSong(int id)
        {
            database.GetCollection<Song>("Songs").Delete(id);
        }

        public Song GetSong(int id)
        {
            return database.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return database.GetCollection<Song>("Songs").FindAll();
        }

        public void UpdateSong(int id, Song song)
        {
            database.GetCollection<Song>("Songs").Update(id, song);
        }

        IEnumerable<Song> IEuroSongDatacontext.GetSongs(string word)
        {
            return database.GetCollection<Song>("Songs").Find(s => s.Title.Contains(word) || s.Artist.Contains(word));
        }
    }
}
