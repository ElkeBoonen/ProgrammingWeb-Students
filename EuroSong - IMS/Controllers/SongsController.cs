using EuroSong.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroSong.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private IEuroSongDatacontext _data;

        public SongsController(IEuroSongDatacontext data)
        {
            _data = data;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Song>> Get(string word = "")
        {
            if (word !="") return Ok(_data.GetSongs(word).ToList()); 
            return Ok(_data.GetSongs()); 
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        {
            /*
             * Quick & dirty oplossing, doen we niet!
             * 
             * foreach (var song in _data.GetSongs())
            {
                if (song.ID == id) return song;
            }
            return NotFound("Oepsie!");
            */
            Song s = _data.GetSong(id);
            if (s!=null) return s;
            return NotFound("Oepsie! Probeer een andere ID");
        }

        /*[HttpGet("Title/{word}")]
        public ActionResult<IEnumerable<Song>> Get(string word)
        {
            return _data.GetSongs(word).ToList();
        }*/

        [HttpPost]
        public ActionResult Post([FromBody] Song song)
        {
            _data.AddSong(song);
            return Ok("Hooray!!");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _data.DeleteSong(id);
            return Ok("Song was deleted");
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody]Song song)
        {
            _data.UpdateSong(id, song);
            return Ok("Song was updated");
        }
    }
}
