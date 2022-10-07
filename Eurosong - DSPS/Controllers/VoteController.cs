using Eurosong___DSPS.Data;
using Eurosong___DSPS.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eurosong___DSPS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private IDataContext _dataContext;

        public VoteController(IDataContext data)
        {
            _dataContext = data;
        }
        
        [HttpPost]
        public ActionResult Post(Vote vote)
        { 
            _dataContext.AddVote(vote);
            return Ok("Hooray!");
        }

        [HttpGet]
        public ActionResult<List<Vote>> Get()
        {
            return Ok(_dataContext.GetVotes());
        }
    }
}