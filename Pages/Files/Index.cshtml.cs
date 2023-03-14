using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace OfficialProject3.Pages.Files
{
    public class IndexModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public IndexModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public PaginatedList<Item> Items { get; set; } = default!;
        public string InputType { get; set; } = String.Empty;

        public async Task OnGetAsync(string? type, string searchString, int? pageIndex)
        {
            if (pageIndex == null)
            {
                pageIndex = 1;
            }
            CurrentFilter = searchString;
            if (_context.Item != null)
            {
                IQueryable<Item> list = _context.Item;
                foreach(var item in list)
                {
                    item.User = await _context.Users.FindAsync(item.UserId);
                }

                if (!String.IsNullOrWhiteSpace(searchString)) 
                {
                    list = list
                        .Where(i => i.Name.Contains(searchString));
                }

                if (type != null)
                {
                    //Type isn't defined
                    if (!Enum.IsDefined(typeof(FileType), type))
                    {
                        NotFound();
                        return;
                    }
                    InputType = type;
                    list = list.Where(i => i.Type == (FileType)Enum.Parse(typeof(FileType), type));
                }
                //Declare items per page
                var pageSize = 4;
                Items = await PaginatedList<Item>.CreateAsync(
                    list, pageIndex ?? 1, pageSize);
            }
        }
    }
}
