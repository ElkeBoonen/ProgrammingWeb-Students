using Eurosong___DSPS.Models;

namespace Eurosong___DSPS.Data
{
    public interface IDataContext
    {
        /// SONGS
        void AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Song GetSong(int id);   

        /// ARTISTS
        void AddArtist(Artist artist);
        IEnumerable<Artist> GetArtists();

        /// VOTES
        void AddVote(Vote vote);
        IEnumerable<Vote> GetVotes();

    }
}
