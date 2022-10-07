using Eurosong___DSPS.Data;
using Eurosong___DSPS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private IDataContext _dataContext;

        public ArtistController(IDataContext data)
        {
            _dataContext = data;
        }
        
        [HttpPost]
        public ActionResult Post(Artist artist)
        { 
            _dataContext.AddArtist(artist);
            return Ok("Hooray!");
        }

        [HttpGet]
        public ActionResult<List<Artist>> Get()
        {
            return Ok(_dataContext.GetArtists());
        }
    }
}