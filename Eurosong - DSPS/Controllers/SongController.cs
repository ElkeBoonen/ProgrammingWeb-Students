using Eurosong___DSPS.Data;
using Eurosong___DSPS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private IDataContext _dataContext;

        public SongController(IDataContext data)
        {
            _dataContext = data;
        }
        
        [HttpPost]
        [Authorize(Policy = "BasicAuthentication")]
        public ActionResult Post(Song song)
        { 
            _dataContext.AddSong(song);
            return Ok("Hooray!");
        }

        [HttpGet]
        public ActionResult<List<Song>> Get()
        {
            return Ok(_dataContext.GetSongs());
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        { 
            Song song = _dataContext.GetSong(id);
            if (song == null) return NotFound("Wrong ID");
            return Ok(song);
        }

        
        //get all songs with specific word in title
        [HttpGet("/Song/Title")]
        public ActionResult<IEnumerable<Song>> Get(string word)
        {
            return Ok(_dataContext.GetSongs(word));
        }

        [HttpGet("/[controller]/Artist")]
        public ActionResult<IEnumerable<Song>> GetSongs(string artist)
        {
            return Ok(_dataContext.GetSongsByArtist(artist));
        }

        [HttpDelete]
        [Authorize(Policy = "BasicAuthentication", Roles = "admin")]
        public ActionResult DeleteSong(int id)
        {
            if (_dataContext.GetSong(id) == null) return NotFound();
            _dataContext.DeleteSong(id);
            return Ok();
        }
    }
}