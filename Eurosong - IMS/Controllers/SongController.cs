using Eurosong___IMS.Data;
using Eurosong___IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___IMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : ControllerBase
    {
        private IDataContext _data;

        public SongController(IDataContext data)
        {
            _data = data;
        }

        [HttpPost]
        public ActionResult Post(Song song)
        {
            _data.AddSong(song);
            return Ok("Song posted");
        }

        [HttpGet]
        public ActionResult<List<Song>> Get(string word="")
        {
            if (word == String.Empty) return Ok(_data.GetSongs());
            else return Ok(_data.GetSongsByWord(word));
        }

        /*
        [HttpGet]
        [Route("Search")]
        public ActionResult<List<Song>> GetByWordInTitle(string word)
        {
            return Ok(_data.GetSongsByWord(word));
        }*/

        [HttpGet("{id}")]
        public ActionResult<Song> GetByID(int id)
        {
            Song temp = _data.GetSongById(id);
            if (temp == null) return NotFound("Id not found");
            return Ok(temp);
        }


    }
}