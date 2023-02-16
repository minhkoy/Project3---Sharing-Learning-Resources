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
    public class DetailsModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public DetailsModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Report Report { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Report == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.Id == id);
            if (report == null)
            {
                return NotFound();
            }
            else 
            {
                Report = report;
            }
            return Page();
        }
    }
}
