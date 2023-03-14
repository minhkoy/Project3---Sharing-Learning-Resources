using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Models;

namespace OfficialProject3.Pages.Files
{
    public class EditModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public EditModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> TypeList { get; } = new List<SelectListItem>
            {
                new SelectListItem {Value = null, Disabled = true, Text = "Chọn thể loại tài liệu... "},
                new SelectListItem {Value = FileType.Basic.ToString(), Text = "Đại cương"},
                new SelectListItem {Value = FileType.BasicIT.ToString(), Text = "Cơ sở ngành CNTT"},
                new SelectListItem {Value = FileType.AdvancedIT.ToString(), Text = "Chuyên ngành IT"}
            };

        [BindProperty]
        public Item Item { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Item == null)
            {
                return NotFound();
            }

            var item =  await _context.Item.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            Item = item;
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(Item.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ItemExists(int id)
        {
          return (_context.Item?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
