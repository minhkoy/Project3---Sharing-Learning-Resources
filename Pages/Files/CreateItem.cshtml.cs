using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficialProject3.Data;
using OfficialProject3.Models;

#nullable disable
namespace OfficialProject3.Pages.Files
{
    public class CreateItemModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext? _context;
        private IWebHostEnvironment? _environment;
        private UserManager<User> _userManager;
        public string tempType { get; set; } = String.Empty;

        public CreateItemModel(ApplicationDbContext context, IWebHostEnvironment? environment,
            UserManager<User> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }
        public List<SelectListItem>? TypeList { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = null, Disabled = true, Text = "Chọn thể loại tài liệu... "},
                new SelectListItem {Value = "Basic", Text = "Đại cương"},
                new SelectListItem {Value = "BasicIT", Text = "Cơ sở ngành CNTT"},
                new SelectListItem {Value = "AdvancedIT", Text = "Chuyên ngành IT"}
            };

        public void OnGet(string type)
        {
            tempType = type;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        //public Item Item { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Item item = new Item(Input.Name, Input.Description, Input.Type,
                Input.SubjectCode);
            
            ClaimsPrincipal currentUser = this.User;
            item.UserId = _userManager.GetUserId(User);
            
            _context.Item.Add(item);
            
            await _context.SaveChangesAsync();

            var file = Input.File;
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_environment.ContentRootPath, "docs");
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return RedirectToPage("/Index");
            }
            
            return Page();
        }
        [RequestSizeLimit(1 * 1024 * 1024)]
        public class InputModel
        {
            [Required(ErrorMessage = "Hãy nhập tên file!")]
            [StringLength(50, ErrorMessage = "Không nhập tên file quá {0} kí tự!")]
            [Display(Name = "Tên tài liệu")]
            public string Name { get; set; } = String.Empty;
            [Required(ErrorMessage = "Hãy mô tả 1 chút về tài liệu của bạn!")]
            [Display(Name = "Mô tả")]
            public string Description { get; set; } = String.Empty;
            [Required(ErrorMessage = "Hãy chọn loại tài liệu!")]
            [Display(Name = "Thể loại")]
            public string Type { get; set; } = String.Empty;
            [Required(ErrorMessage = "Cần nhập mã môn học!"), Display(Name = "Mã môn học")]
            public string SubjectCode { get; set; } = String.Empty;
            [Required(ErrorMessage = "Hãy upload file!")]
            [Display(Name = "Hãy upload tài liệu của bạn ở đây!")]
            public IFormFile? File { get; set; } = null;
        }
    }
}
