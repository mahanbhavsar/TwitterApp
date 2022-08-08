
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterWebAPI.Models
{
    public class Tweet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TweetId { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(144)]
        public string? TweetText { get; set; }
        [MaxLength(50)]
        public string? Tags { get; set; }
        public List<Reply>? Replies { get; set; }
    }
}
