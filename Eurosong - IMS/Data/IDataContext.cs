using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    public interface IDataContext
    {
        /*
            SONG-METHODES
         */
        void AddSong(Song song);
        IEnumerable<Song> GetSongs();
        Song GetSong(int id);

        /*
           ARTIST-METHODES
        */

        void AddArtist(Artist artist);
        IEnumerable<Artist> GetArtists();
        Artist GetArtist(int id);
        IEnumerable<Song> GetSongList(int artist);
    }
}
