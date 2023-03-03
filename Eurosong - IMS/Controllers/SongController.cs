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
        public ActionResult<List<Song>> Get()
        {
            return Ok(_data.GetSongs());
        }


    }
}