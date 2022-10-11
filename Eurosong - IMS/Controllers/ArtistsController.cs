using Eurosong___IMS.Data;
using Eurosong___IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___IMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        IDataContext _dataContext;

        public ArtistsController(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpPost]
        public void Post(Artist artist)
        {
            _dataContext.AddArtist(artist);
        }

        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            return _dataContext.GetArtists();
        }

        [HttpGet("{id}")]
        public ActionResult<Artist> Get(int id)
        { 
            Artist artist = _dataContext.GetArtist(id);
            if (artist == null) return NotFound("Wrong artist id");
            return Ok(artist);
        }

        [HttpGet("{artistID}/songs")]//[HttpGet("GetAllSongs")]
        public ActionResult<IEnumerable<Song>> GetAllSongs(int artistID)
        { 
            List<Song> songs = _dataContext.GetSongList(artistID).ToList();
            if (songs.Count == 0) return NotFound("No songs found!");
            return Ok(songs);

        }
    }
}
