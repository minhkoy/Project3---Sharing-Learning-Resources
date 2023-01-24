//using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace OfficialProject3.Models
{
    public class Item
    {
        private static int StaticID = 1;
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Hãy nhập tên file!")]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Type { get; set; } = String.Empty;
        [NotMapped]
        public int ViewedCount { get; } = 0;
        [NotMapped]
        public int DownloadedCount { get; } = 0;
        [Display(Name = "Mã môn học")]
        [ForeignKey("Mã môn học")]
        public string SubjectCode { get; set; } = String.Empty;
        [Required(ErrorMessage = "Chưa có file nào được up lên!")]
        public string? FileLink { get; set; } = String.Empty;
        [ForeignKey("User")]
        public string UserId { get; set; }
        //Navigation props
        public User User { get; set; }
        //public Image? Image { get; set; } = null;
        public Item() {}
        public Item(string name, string description, string type,
            string subjectCode, string fileLink) 
        {
            Id = StaticID++;
            Name = name;
            Description = description;
            Type = type;
            SubjectCode = subjectCode;
            FileLink = fileLink;
        }
        public Item(string name, string description, string type, string subjectCode)
        {
            Id = StaticID++;
            Name = name;
            Description = description;
            Type = type;
            SubjectCode = subjectCode;
        }
    }
}
