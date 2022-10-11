using Eurosong___IMS.Models;

namespace Eurosong___IMS.Data
{
    //deze klasse is enkel ter illustratie!!!
    //niet meer van belang in onze API
    public class DataList : IDataContext
    {
        List<Song> _songs = new List<Song>();

        public void AddArtist(Artist artist)
        {
            throw new NotImplementedException();
        }

        public void AddSong(Song song)
        {
            _songs.Add(song);
        }

        public Artist GetArtist(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Artist> GetArtists()
        {
            throw new NotImplementedException();
        }

        public Song GetSong(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongList(int artist)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Song> GetSongs()
        {
            return _songs;
        }
    }
}
