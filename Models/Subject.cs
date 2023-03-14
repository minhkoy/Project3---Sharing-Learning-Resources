using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace OfficialProject3.Models
{
    public class Subject
    {
        [Key]
        public string SubjectCode { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

    }
}
