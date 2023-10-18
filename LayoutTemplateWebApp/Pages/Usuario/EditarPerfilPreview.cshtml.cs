using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EmparejaTecWebApp.Pages.Usuario
{

    public class EditarPerfilPreviewModel : PageModel
    {
        public AppUser AppUser { get; set; }

        private readonly ApplicationDBContext _db;

        public List<Interest> Interests { get; set; } = new List<Interest>();

        //constructor
        public EditarPerfilPreviewModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            var email = HttpContext.Session.GetString("email");
            AppUser = _db.AppUser.Find(email);

            List<AppUserXInterest> appUserXInterest = _db.AppUserXInterest.Where(a => a.email == email).ToList();
            List<Interest> interests = _db.Interest.ToList();

            // Iterate through the list of AppUserXInterest and iterate through the list of Interest
            // where there is a match between the interestId of both tables and save the interest to class variable Interests
            foreach (var item in appUserXInterest)
            {
                foreach (var interest in interests)
                {
                    if (item.idInterest == interest.idInterest)
                    {
                        Interests.Add(interest);
                    }
                }
            }
        }
    }

}
