using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OfficialProject3.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public IndexModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Report != null)
            {
                Report = await _context.Report
                .Include(r => r.ReportedComment)
                .Include(r => r.ReportedItem).ToListAsync();
            }
        }
    }
}
