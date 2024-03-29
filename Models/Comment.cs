﻿using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.DateTime), Display(Name = "Ngày đăng")]
        public DateTime CommentDate { get; set; }
        public int Upvote { get; set; } = 0;
        public int Downvote { get; set; } = 0;
        //Navigation properties
        [Display(Name = "Người đăng")]
        public User User { get; set; }
        public Item Item { get; set; }
        //Constructor
        public Comment() { }

    }
}
