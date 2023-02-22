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
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; } = string.Empty;
        [Required, StringLength(maximumLength: 500, ErrorMessage = "Báo cáo độ dài tối đa 500 ký tự!"),
         Display(Name = "Nội dung")]
        public string Content { get; set; } = string.Empty;
        [Display(Name = "Loại báo cáo")]
        public ReportType ReportType { get; set; }
        [ForeignKey("Reporter")]
        public string UserId { get; set; }
        [Display(Name = "Id người báo cáo")]
        public User Reporter { get; set; }
        //Only apply when the report type is File Report
        [ForeignKey("ReportedItem")]
        public int? ItemId { get; set; }
        [Display(Name = "Id tài liệu")]
        public Item? ReportedItem { get; set; }
        //Only apply when the report type is Comment Report
        [ForeignKey("ReportedComment")]
        public string? CommentId { get; set; }
        [Display(Name = "Id bình luận")]
        public Comment? ReportedComment { get; set; }
    }
}
