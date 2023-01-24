using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace OfficialProject3.Models
{
    public class ChildItem
    {
        public ChildItem(string name, string description, string type, string subjectCode) //: base(name, description, type, subjectCode)
        {
        }
/*
        public Image? Image { get; set; } = null;
        [Required]
        public FormFile? File { get; set; } = null;
        public ChildItem(string name, string description, string type, string subjectCode, Image? image, FormFile? file) : base(name, description, type, subjectCode) 
        {
            Image = image;
            File = file;
        } */
    }
}
