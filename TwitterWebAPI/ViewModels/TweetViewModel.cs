namespace TwitterWebAPI.ViewModels
{
    public class TweetViewModel
    {
        public int TweetId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? TweetText { get; set; }
        public string? Tags { get; set; }
        public List<ReplyViewModel>? Replies { get; set; }
    }
}
