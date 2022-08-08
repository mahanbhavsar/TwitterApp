namespace TwitterWebAPI.ViewModels
{
    public class ReplyViewModel
    {
        public int ReplyId { get; set; }
        public int TweetId { get; set; }
        public int ReplyByUserId { get; set; }
        public string? ReplyText { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Tags { get; set; }
    }
}
