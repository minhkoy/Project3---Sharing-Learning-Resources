using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OfficialProject3.Models
{
    public class User : IdentityUser
    {
        [Display(Name = "Tên đầy đủ")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Ngày sinh"), Required]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Mô tả một chút về bản thân bạn nhé")]
        public string? Description { get; set; }
        [Display(Name = "Trường học"), Required]
        public string School { get; set; }
        [Display(Name = "Ngành học")]
        public string? Branch { get; set; }
        [Display(Name = "Số lượt bị báo cáo")]
        public int ReportedCount { get; set; }
        public List<Item> Items { get; set; }
        public bool IsRemoved { get; set; } = false;
    }
}
