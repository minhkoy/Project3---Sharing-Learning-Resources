using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OfficialProject3.Pages.Files
{
    public class DetailsModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;

        public DetailsModel(OfficialProject3.Data.ApplicationDbContext context, IWebHostEnvironment environment,
            UserManager<User> userManager)
        {
            _context = context;
            _environment = environment;
            _userManager = userManager;
        }
        public Item? Item { get; set; } = default!;
        [BindProperty]
        public Report CommentReport { get; set; } = default!;
        [BindProperty]
        public Report FileReport { get; set; } = default!;
        [BindProperty]
        public Comment Comment { get; set; } = default!;
        public IList<Comment> CommentList { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);
#nullable disable
            item.User = await _context.Users.Where(u => u.Id == item.UserId).FirstOrDefaultAsync();
#nullable enable
            CommentList = _context.Comment.Where(c => c.ItemId == id).OrderByDescending(c => c.CommentDate).ToList();
            foreach (var comment in CommentList)
            {
                comment.User = _context.Users.Where(u => comment.UserId == u.Id).FirstOrDefault();
            }
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Item = item;
                Item.ViewedCount++;
                await _context.SaveChangesAsync();
            }
            var filePath = Item.FileLink;
            if (System.IO.File.Exists(filePath))
            {
                
            }
            return Page();
        }
        public async Task<IActionResult> OnPostCreateCommentAsync(int? id, string? commentId)
        {
            if (id == null || _context.Item == null)
            {
                return Page();
            }
            await OnGetAsync(id);
            Comment.Id = Guid.NewGuid().ToString();
            _context.Comment.Add(Comment);
            
            await _context.SaveChangesAsync();
            return RedirectToPage();
            //return LocalRedirect($"/{Item.Id}");
        }
        public async Task<IActionResult> OnPostDeleteCommentAsync(int id, string? commentId)
        {
            await OnGetAsync(id);    
            if (commentId == null || _context.Comment == null)
            {
                return NotFound();
            }
            var comment = await _context.Comment.FindAsync(commentId);

            if (comment != null)
            {
                Comment = comment;
                var relatedReports = _context.Report.Where(r => r.CommentId == comment.Id);
                _context.Comment.Remove(Comment);
                _context.Report.RemoveRange(relatedReports);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostReportCommentAsync(int id)
        {
            _context.Report.Add(CommentReport);
            await _context.SaveChangesAsync();
            await OnGetAsync(id);
            Console.WriteLine($"REPORT: {CommentReport.Content}");
            return RedirectToPage();
        }
        public async Task<IActionResult> OnPostReportFile(int id)
        {
            _context.Report.Add(FileReport); 
            await _context.SaveChangesAsync();
            await OnGetAsync(id);
            Console.WriteLine($"REPORT: {FileReport.Content}");
            return RedirectToPage();
        }
    }
}
