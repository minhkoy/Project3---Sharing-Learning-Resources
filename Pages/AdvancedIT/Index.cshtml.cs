using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OfficialProject3.Pages.AdvancedIT
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
        
        public IActionResult OnPostCreateItem()
        {
            return RedirectToPage("/Files/Create");
        }
    }
}
