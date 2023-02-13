using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Models;

namespace OfficialProject3.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public IndexModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Report> Report { get;set; } = default!;

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
