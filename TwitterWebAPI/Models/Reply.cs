using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TwitterWebAPI.Models
{
    public class Reply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReplyId { get; set; }
        [Required]
        public int TweetId { get; set; }
        public Tweet? Tweet { get; set; }
        public int ReplyByUserId { get; set; }
        [MaxLength(144)]
        public string? ReplyText { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [MaxLength(50)]
        public string? Tags { get; set; }

    }
}
