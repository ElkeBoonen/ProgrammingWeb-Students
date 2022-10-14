using Eurosong___DSPS.Models;
using LiteDB;

namespace Eurosong___DSPS.Data
{
    public class Database : IDataContext
    {
        private LiteDatabase _data = new LiteDatabase("data.db");

        public void AddArtist(Artist artist)
        {
            _data.GetCollection<Artist>("Artists").Insert(artist);
        }

        public void AddSong(Song song)
        {
            _data.GetCollection<Song>("Songs").Insert(song);
        }

        public void AddVote(Vote vote)
        {
            _data.GetCollection<Vote>("Votes").Insert(vote);
        }

        public IEnumerable<Artist> GetArtists()
        {
            return _data.GetCollection<Artist>("Artists").FindAll();
        }

        public Song GetSong(int id)
        {
            return _data.GetCollection<Song>("Songs").FindById(id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return _data.GetCollection<Song>("Songs").FindAll();
        }

        public IEnumerable<Vote> GetVotes()
        {
            return _data.GetCollection<Vote>("Votes").FindAll();
        }
    }
}
