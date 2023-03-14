//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Hãy nhập tên file!")]
        [Display(Name = "Tên tài liệu")]
        public string Name { get; set; } = String.Empty;
        [Display(Name = "Mô tả")]
        public string Description { get; set; } = String.Empty;
        [Display(Name = "Phân loại")]
        public FileType Type { get; set; } = FileType.Basic;
        //[NotMapped]
        [Display(Name = "Số lượt xem")]
        public int ViewedCount { get; set; } = 0;
        //[NotMapped]
        [Display(Name = "Số lượt tải về")]
        public int DownloadedCount { get; set; } = 0;
        [Display(Name = "Mã môn học")]
        [ForeignKey("Mã môn học")]
        public string SubjectCode { get; set; } = String.Empty;
        [Required(ErrorMessage = "Chưa có file nào được up lên!")]
        public string? FileLink { get; set; } = String.Empty;
        [ForeignKey("User")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; } = String.Empty;
        [Display(Name = "Tác giả")]
        //Navigation props
        public User? User { get; set; } = null;
        public Item() { }
        public Item(string name, string description, FileType type,
            string subjectCode, string fileLink, string userId)
        {
            Random rand = new Random();
            Id = rand.Next(100000000);
            //Id = new Guid().ToString();
            Name = name;
            Description = description;
            Type = type;
            SubjectCode = subjectCode;
            FileLink = fileLink;
            UserId = userId;
        }
    }
}
