using Eurosong___DSPS.Models;

namespace Eurosong___DSPS.Data
{
    public class DataList : IDataContext
    {
        private List<Song> _songs = new List<Song>();
        private List<Artist> _artists = new List<Artist>();
        private List<Vote> _votes = new List<Vote>();

        /*
         ************ SONGS
         */

        public void AddSong(Song song)
        {
           _songs.Add(song);
        }
        public IEnumerable<Song> GetSongs()
        {
            return _songs;
        }

        /*
        ************ ARTISTS
        */
        public void AddArtist(Artist artist)
        {
            _artists.Add(artist);
        }

  
        public IEnumerable<Artist> GetArtists()
        {
            return _artists;
        }

        /*
        ************ VOTES
        */
        public void AddVote(Vote vote)
        {
            _votes.Add(vote);
        }

        public IEnumerable<Vote> GetVotes()
        {
            return _votes;
        }

        public Song GetSong(int id)
        {
            throw new NotImplementedException();
        }
    }
}
