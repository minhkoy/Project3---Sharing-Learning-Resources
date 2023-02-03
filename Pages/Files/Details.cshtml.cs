using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficialProject3.Data;
using OfficialProject3.Models;

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
        public Item Item { get; set; } = default!;
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
            CommentList = _context.Comment.Where(c => c.ItemId == id).OrderByDescending(c => c.CommentDate).ToList();
            foreach(var comment in CommentList)
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
            }
            var filePath = Item.FileLink;
            //if (System.IO.File.Exists(filePath))
            //{
                
            //}
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Comment.Id = Guid.NewGuid().ToString();
            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Files/Details", new {id = Comment.ItemId});
        }
    }
}
