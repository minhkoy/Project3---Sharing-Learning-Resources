using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Models;

namespace OfficialProject3.Pages.Files
{
    public class DetailsModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public DetailsModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
