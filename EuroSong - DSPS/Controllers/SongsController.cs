using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroSong___DSPS.Data;


namespace EuroSong___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private IEuroSongDataContext _data;

        public SongsController(IEuroSongDataContext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get(string title = "")
        {
            if (title != "") return Ok(_data.GetSpecificSongs(title));
            return Ok(_data.GetSongs());
        }

        /*[HttpGet("Title/{word}")]
        public ActionResult<IEnumerable<Song>> Get(string title)
        {
            return Ok(_data.GetSpecificSongs(title));
        }*/

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            Song song = _data.GetSongById(id);
            if (song != null) return Ok(song);
            return NotFound("Song was not found!");
        }

        [HttpPost]
        public ActionResult Post([FromBody]Song song)
        {
            _data.AddSong(song);
            return Ok("Song was added!");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteSong(id);
            return Ok("Song was deleted!");
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody]Song song)
        {
            _data.UpdateSong(id, song);
            return Ok("Song was updated!");
        }
    }
}
