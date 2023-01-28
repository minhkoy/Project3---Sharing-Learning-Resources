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
    public class IndexModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public IndexModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Item> Item { get;set; } = default!;

        public async Task OnGetAsync(string? type)
        {
            if (_context.Item != null)
            {
                var list = await _context.Item
                    .Include(i => i.User).ToListAsync();
                if (type == null)
                {
                    Item = list;
                }
                else
                {
                    //Type isn't defined
                    if (!Enum.IsDefined(typeof(FileType), type))
                    {
                        NotFound();
                        return;
                    }
                    Item = list.Where(i => i.Type.ToString() == type).ToList();
                }
            }
        }
    }
}
