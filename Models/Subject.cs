using Microsoft.Build.Framework;

namespace OfficialProject3.Models
{
    public class Subject
    {
        [Required]
        public string SubjectCode { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

    }
}
