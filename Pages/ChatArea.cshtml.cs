using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OfficialProject3.Pages
{
    public class ChatAreaModel : PageModel
    {
        public int UsersOnline { get; set; }
        public void OnGet()
        {
        }
    }
}
