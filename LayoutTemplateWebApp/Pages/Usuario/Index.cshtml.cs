using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmparejaTecWebApp.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        public string role { get; set; }
        public string avatarPath { get; set; }
        public void OnGet()
        {
            avatarPath = HttpContext.Session.GetString("avatarPath");
            role = HttpContext.Session.GetString("role");
        }
    }
}
