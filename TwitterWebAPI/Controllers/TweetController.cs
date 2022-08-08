using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterWebAPI.Auth;
using TwitterWebAPI.Models;
using TwitterWebAPI.Services;
using TwitterWebAPI.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TwitterWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TweetController : ControllerBase
    {        
        private readonly ITweetsRepository _tweetsRepository;
        private readonly IMapper _mapper;

        public TweetController(ITweetsRepository tweetsRepository, IMapper mapper)
        {
            _tweetsRepository = tweetsRepository;
            _mapper = mapper;
        }

        // GET: api/<TweetsController>
        [HttpGet]
        [Route("GetAllTweets")]
        public ActionResult<IEnumerable<TweetViewModel>> GetAllTweets()
        {
            var tweets = _tweetsRepository.GetAllTweets();
            return this.Ok(_mapper.Map<IEnumerable<TweetViewModel>>(tweets));
        }

        // GET api/<TweetsController>
        [HttpGet]
        [Route("GetTweetsByUser")]
        public ActionResult<IEnumerable<TweetViewModel>> GetTweetsByUser()
        {
            var userName = Request.HttpContext.User.Identity?.Name;
            if(userName == null)
            {
                return NotFound("User not found");
            }
            var tweets = _tweetsRepository.GetTweetsByUser(userName);
            return this.Ok(_mapper.Map<IEnumerable<TweetViewModel>>(tweets));
        }

        // POST api/<TweetsController>
        [HttpPost]
        [Route("PostTweet")]
        public ActionResult<TweetViewModel> PostTweet([FromBody] Tweet tweet)
        {
            var userName = Request.HttpContext.User.Identity?.Name;
            if (userName == null)
            {
                return NotFound("User not found");
            }
            var returnedTweet = _tweetsRepository.PostTweet(tweet, userName);

            return this.Ok(_mapper.Map<TweetViewModel>(returnedTweet));
        }

        // POST api/<TweetsController>
        [HttpPost]
        [Route("PostReply")]
        public ActionResult<ReplyViewModel> PostReply([FromBody] Reply reply)
        {
            var userName = Request.HttpContext.User.Identity?.Name;
            if (userName == null)
            {
                return NotFound("User not found");
            }
            var returnedReply = _tweetsRepository.PostReply(reply, userName);

            return this.Ok(_mapper.Map<ReplyViewModel>(returnedReply));
        }        
    }
}
