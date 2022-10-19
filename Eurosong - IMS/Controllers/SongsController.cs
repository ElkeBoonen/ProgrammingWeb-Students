using Eurosong___IMS.Data;
using Eurosong___IMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___IMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {

        //static List<Song> _songs = new List<Song>();
        IDataContext _dataContext;

        public SongsController(IDataContext data)
        {
            _dataContext = data;
        }
       
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _dataContext.GetSongs();
        }

        [HttpPost]
        [Authorize(Policy = "BasicAuthentication")]
        public ActionResult Post(Song song)
        { 
            _dataContext.AddSong(song);
            return Ok("Song toegevoegd!");
        }

        [HttpPut]
        public ActionResult Update(int id, Song song)
        {
            return Ok("Song aangepast!");
        }

        [HttpGet("{id}")]
        public ActionResult<Song> Get(int id)
        { 
            Song song = _dataContext.GetSong(id);
            if (song == null) return NotFound("Wrong id!");
            return Ok(song);
        }

        [HttpDelete]
        [Authorize(Policy = "BasicAuthentication", Roles = "admin")]
        public ActionResult<Song> Delete(int id)
        {
            Song song = _dataContext.Delete(id);
            if (song == null) return NotFound("No song to delete!");
            return Ok(song);
        }
    }
}