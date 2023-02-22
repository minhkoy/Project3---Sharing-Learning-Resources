using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OfficialProject3.Pages.Files
{
    public class DeleteModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public DeleteModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Item Item { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FirstOrDefaultAsync(m => m.Id == id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                Item = item;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }
            var item = await _context.Item.FindAsync(id);

            if (item != null)
            {
                Item = item;
                var reportsToDelete = await _context.Report.Where(r => r.ItemId == Item.Id).ToListAsync();
                if (reportsToDelete.Count != 0) _context.Report.RemoveRange(reportsToDelete);
                var commentsToDelete = await _context.Comment.Where(c => c.ItemId == Item.Id).ToListAsync();
                if (commentsToDelete.Count != 0) _context.Comment.RemoveRange(commentsToDelete);
                _context.Item.Remove(Item);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
