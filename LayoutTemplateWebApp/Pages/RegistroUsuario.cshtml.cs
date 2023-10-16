using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmparejaTecWebApp.Pages
{
    public class RegistroUsuarioModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IEnumerable<Interest> Interests { get; set; }

        public AppUser AppUser { get; set; }

        public RegistroUsuarioModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Interests = _db.Interest.ToList();
            AppUser.email = HttpContext.Session.GetString("email");
        }
    }
}
