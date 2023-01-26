//using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace OfficialProject3.Models
{
    public enum FileType
    {
        [Display(Name = "Đại cương")]
        Basic,
        [Display(Name = "Cơ sở ngành CNTT")]
        BasicIT,
        [Display(Name = "Chuyên ngành CNTT")]
        AdvancedIT
    }
    public class Item
    {
        private static int StaticID = 1;
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Hãy nhập tên file!")]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public FileType Type { get; set; }
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        //Navigation props
        public User User { get; set; }
        public Item() {}
        public Item(string name, string description, FileType type,
            string subjectCode, string fileLink, string userId) 
        {
            Id = ++StaticID;
            Name = name;
            Description = description;
            Type = type;
            SubjectCode = subjectCode;
            FileLink = fileLink;
            UserId = userId;
        }
        public Item(string name, string description, FileType type, string subjectCode)
        {
            Id = StaticID++;
            Name = name;
            Description = description;
            Type = type;
            SubjectCode = subjectCode;
        }
    }
}
