using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OfficialProject3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        private static int ViewCount = 0;
        public int Views { get; set; } = 0;

        public void OnGet()
        {
            ViewCount++;
            Views = ViewCount;
        }
    }
}