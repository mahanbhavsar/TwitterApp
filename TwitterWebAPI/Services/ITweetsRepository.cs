using TwitterWebAPI.Models;

namespace TwitterWebAPI.Services
{
    public interface ITweetsRepository
    {
        public IEnumerable<Tweet> GetAllTweets();
        public IEnumerable<Tweet> GetTweetsByUser(string loginId);
        public Tweet PostTweet(Tweet tweet, string userName);
        public Reply PostReply(Reply reply, string userName);
    }
}
