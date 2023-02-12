using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficialProject3.Models
{
    public enum ReportType
    {
        [Display(Name = "Báo cáo tài liệu")]
        FileReport,
        [Display(Name = "Báo cáo bình luận")]
        CommentReport
    }
    public class Report
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(maximumLength: 60, MinimumLength = 5,
            ErrorMessage = "Tiêu đề cần có độ dài 5 - 60 ký tự!"), Required]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(maximumLength: 500, ErrorMessage = "Báo cáo độ dài tối đa 500 ký tự!")]
        public string Content { get; set; } = string.Empty;
        public ReportType ReportType { get; set; }
        //Only apply when the report type is File Report
        [ForeignKey("ReportedItem")]
        public int? ItemId { get; set; }
        public Item? ReportedItem { get; set; }
        //Only apply when the report type is Comment Report
        [ForeignKey("ReportedComment")]
        public string? CommentId { get; set; }
        public Comment? ReportedComment { get; set; }
    }
}
