using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace OfficialProject3.Models
{
    public class Comment
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Hãy nhập bình luận")]
        public string Content { get; set; }
        public int Upvote { get; set; } = 0;
        public int Downvote { get; set; } = 0;
        [DisplayFormat(DataFormatString = "dd-MM-YYYY")]
        public DateTime CommentDate { get; set; }
        //Navigation properties
        [Display(Name = "Người đăng")]
        public User User { get; set; }
        public Item Item { get; set; }
        //Constructor
        public Comment() { }
        
    }
}
