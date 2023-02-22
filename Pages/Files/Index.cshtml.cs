using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OfficialProject3.Pages.Files
{
    public class IndexModel : PageModel
    {
        private readonly OfficialProject3.Data.ApplicationDbContext _context;

        public IndexModel(OfficialProject3.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        //public PaginatedList<Item> Item { get; set; } = default!;
        public IList<Item> Item { get; set; } = default!;
        public string InputType { get; set; } = String.Empty;

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
                    InputType = type;
                    Item = list.Where(i => i.Type.ToString() == type).ToList();
                }
            }
        }
    }
}
