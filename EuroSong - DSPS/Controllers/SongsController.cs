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
        public ActionResult<IEnumerable<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }

        [HttpGet("{word}")]
        public ActionResult<IEnumerable<Song>> Get(string word)
        {
            return Ok(_data.GetSpecificSongs(word));
        }


        [HttpPost]
        public ActionResult Post([FromBody]Song song)
        {
            _data.AddSong(song);
            return Ok("Song was added!");
        }
    }
}
