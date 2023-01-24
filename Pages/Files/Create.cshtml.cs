using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficialProject3.Data;
using OfficialProject3.Models;

namespace OfficialProject3.Pages.Files
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        private UserManager<User> _userManager;
        public CreateModel(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Item? Item { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Item.UserId = _userManager.GetUserId(User);
            Item.User = _context.Users.Where(user => Item.UserId == user.Id).FirstOrDefault();
            if (!ModelState.IsValid || _context.Item == null || Item == null)
            {
                return Page();
            }
          _context.Item.Add(Item);
          await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
