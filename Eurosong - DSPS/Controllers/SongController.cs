using Eurosong___DSPS.Data;
using Eurosong___DSPS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private DataContext _data;

        public SongController(DataContext data)
        {
            this._data = data;
        }
        
        [HttpPost]
        public ActionResult Post(Song song)
        {
            _data.AddSong(song);
            return Ok("Song posted!");
        }

        [HttpGet]
        public ActionResult<List<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }

        /* Other possible solution
           [HttpGet]
            public ActionResult<List<Song>> Get(qtring word)
            {
                return Ok(_data.GetSongsByTitle(word));
            }
         */

        [HttpGet("Search")]
        public ActionResult<List<Song>> GetByTitle(string word)
        {
            return Ok(_data.GetSongsByTitle(word));
        }


    }
}