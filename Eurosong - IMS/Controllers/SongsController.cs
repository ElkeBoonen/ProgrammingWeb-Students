using Eurosong___IMS.Data;
using Eurosong___IMS.Models;
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
        public ActionResult Post(Song song)
        { 
            _dataContext.AddSong(song);
            return Ok("Song toegevoegd!");
        }

        [HttpGet]
        public ActionResult<Song> Get(int id)
        { 
            _dataContext.
        }
    }
}