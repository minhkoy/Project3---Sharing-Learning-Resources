using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace OfficialProject3.Models
{
    public class Comment
    {
        public string Id { get; }
        public string UserId { get; }
        public string ItemId { get; }
        public string Content { get; set; }
        public int Upvote { get; set; }
        public int Downvote { get; set; }
    }
}
