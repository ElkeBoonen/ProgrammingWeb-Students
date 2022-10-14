using Eurosong___DSPS.Data;
using Eurosong___DSPS.Models;
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

        [HttpGet]
        public ActionResult<Song> Get(string word)
        {
           
        }
    }
}