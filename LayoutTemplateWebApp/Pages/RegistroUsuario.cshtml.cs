using EmparejaTecWebApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmparejaTecWebApp.Pages
{
    public class RegistroUsuarioModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public RegistroUsuarioModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }
    }
}
