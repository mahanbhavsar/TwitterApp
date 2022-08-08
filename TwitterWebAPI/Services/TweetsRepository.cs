using Microsoft.EntityFrameworkCore;
using TwitterWebAPI.Models;

namespace TwitterWebAPI.Services
{
    public class TweetsRepository : ITweetsRepository
    {
        private readonly TwitterDbContext _context;
        public TweetsRepository(TwitterDbContext twitterDbContext)
        {
            _context = twitterDbContext;
        }
        
        public IEnumerable<Tweet> GetAllTweets()
        {
            return _context.Tweets.Include(i => i.Replies).ToList();
        }

        public IEnumerable<Tweet> GetTweetsByUser(string loginId)
        {
            var user = _context.Users.FirstOrDefault(x => x.LoginId == loginId);
            return _context.Tweets.Where(x => x.UserId == user.UserId).Include(i=>i.Replies);
        }

        public Reply PostReply(Reply reply, string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.LoginId == userName);
            reply.ReplyByUserId = user.UserId;
            reply.CreatedAt = DateTime.Now;
            _context.Replies.Add(reply);
            _context.SaveChanges();
            return reply;
        }

        public Tweet PostTweet(Tweet tweet, string userName)
        {
            var user = _context.Users.FirstOrDefault(x => x.LoginId == userName);
            tweet.UserId = user.UserId;
            tweet.CreatedAt = DateTime.Now;
            _context.Tweets.Add(tweet);
            _context.SaveChanges();
            return tweet;
        }
    }
}
