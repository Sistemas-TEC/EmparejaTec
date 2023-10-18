using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Extensions;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmparejaTecWebApp.Pages.Usuario
{
    public class EditarPerfilModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public List<Interest> Interests { get; set; } = new List<Interest>();

        public List<Interest> SelectedInterests { get; set; } = new List<Interest>();

        [BindProperty]
        public AppUser AppUser { get; set; }

        public string role { get; set; }
        public EditarPerfilModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // get role from session
            role = HttpContext.Session.GetString("role");
            if (role == null)
            {
                Response.Redirect("/ErrorPage");
            }
            if (Interests == null || !Interests.Any())
            {
                assignInterests();
            }
            var email = HttpContext.Session.GetString("email");
            AppUser = _db.AppUser.Find(email);

            // Save the selected interests to the session
            HttpContext.Session.SetObjectAsJson("selectedInterests", SelectedInterests);
            // Save the interests to the session
            HttpContext.Session.SetObjectAsJson("interests", Interests);

        }

        public void assignInterests()
        {
            var email = HttpContext.Session.GetString("email");

            List<AppUserXInterest> appUserXInterest = _db.AppUserXInterest.Where(a => a.email == email).ToList();
            List<Interest> interests = _db.Interest.ToList();

            // Iterate through the list of AppUserXInterest and iterate through the list of Interest where there is a match between the interestId of both tables and save the interest to class variable SelectedInterests
            // The interests that are not in the list of AppUserXInterest are saved to class variable Interests
            foreach (var interest in interests)
            {
                if (appUserXInterest.Any(a => a.idInterest == interest.idInterest))
                {
                    SelectedInterests.Add(interest);
                }
                else
                {
                    Interests.Add(interest);
                }
            }
        }


        public async Task<IActionResult> OnPost(AppUser appUser)
        {
            // Get selected interests from the session
            this.SelectedInterests = HttpContext.Session.GetObjectFromJson<List<Interest>>("selectedInterests");
            // Access the selected gender

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@email", (object)HttpContext.Session.GetString("email") ?? DBNull.Value),
                new SqlParameter("@username", (object)appUser.username ?? DBNull.Value),
                new SqlParameter("@summary", (object)appUser.summary ?? DBNull.Value),
                new SqlParameter("@age", DBNull.Value),  // If you know this is always null, you can directly assign DBNull.Value
                new SqlParameter("@idGender", DBNull.Value),
                new SqlParameter("@idUserStatus", DBNull.Value),
                new SqlParameter("@avatarPath", (object)HttpContext.Session.GetString("avatarPath") ?? DBNull.Value),
                new SqlParameter("@bannerPath", (object)HttpContext.Session.GetString("coverPath") ?? DBNull.Value)
            };

            int rows = await _db.Database.ExecuteSqlRawAsync("EXEC sp_EditAppUser @email,"
                + "@username, @summary, @age, @idGender, @idUserStatus, "
                + "@avatarPath, @bannerPath", parameters);
            if (rows > 0)
            {
                // Delete all the interests of the user with sp_DeleteAppUserXInterestByEmail
                var parameters3 = new SqlParameter[]
                {
                    new SqlParameter("@email",
                                           HttpContext.Session.GetString("email"))
                };
                await _db.Database.ExecuteSqlRawAsync("EXEC sp_DeleteAppUserXInterestByEmail @email",
                                       parameters3);

                // Iterate through the selected interests
                foreach (var interest in SelectedInterests)
                {
                    // Add the interest to the database
                    var parameters2 = new SqlParameter[]
                    {
                        new SqlParameter("@email",
                            HttpContext.Session.GetString("email")),
                        new SqlParameter("@idInterest",
                            interest.idInterest)
                    };
                    int rows2 = await _db.Database.ExecuteSqlRawAsync("EXEC sp_InsertAppUserXInterest @email, @idInterest", parameters2);
                    if (rows2 <= 0)
                    {
                        return RedirectToPage("/ErrorPage");
                    }
                }
                return RedirectToPage("/Usuario/EditarPerfilPreview");
            }
            else
            {
                return RedirectToPage("/ErrorPage");
            }
        }



        [HttpPost]
        public JsonResult OnPostAddInterest(string interest)
        {
            // Get the interests from the session
            this.Interests = HttpContext.Session.GetObjectFromJson<List<Interest>>("interests");
            this.SelectedInterests = HttpContext.Session.GetObjectFromJson<List<Interest>>("selectedInterests");

            // Find the interest in Interests
            var newInterest = Interests.FirstOrDefault(item => item.interest == interest);
            if (newInterest != null)
            {
                // Add the interest to SelectedInterests
                SelectedInterests.Add(newInterest);
                // Remove the interest from Interests
                Interests = Interests.Where(item => item.interest != interest).ToList();
            }
            // Update the session
            HttpContext.Session.SetObjectAsJson("selectedInterests", SelectedInterests);
            HttpContext.Session.SetObjectAsJson("interests", Interests);

            // Return a JSON result to indicate success
            return new JsonResult(new { success = true });
        }



        [HttpPost]
        public JsonResult OnPostRemoveInterest(string interest)
        {
            // Get the interests from the session
            this.Interests = HttpContext.Session.GetObjectFromJson<List<Interest>>("interests");
            this.SelectedInterests = HttpContext.Session.GetObjectFromJson<List<Interest>>("selectedInterests");
            // Find the interest in SelectedInterests
            var interestToRemove = SelectedInterests.FirstOrDefault(item => item.interest == interest);
            if (interestToRemove != null)
            {
                // Remove the interest from SelectedInterests
                SelectedInterests = SelectedInterests.Where(item => item.interest != interest).ToList();
                // Add the interest to Interests
                Interests.Add(interestToRemove);
            }
            // Update the session
            HttpContext.Session.SetObjectAsJson("selectedInterests", SelectedInterests);
            HttpContext.Session.SetObjectAsJson("interests", Interests);

            // Return a JSON result to indicate success
            return new JsonResult(new { success = true });
        }


        [HttpPost]
        public JsonResult OnPostSetAvatarPath(string avatarPath)
        {
            // Save the avatarPath to the session
            HttpContext.Session.SetString("avatarPath", avatarPath);

            // Return a JSON result to indicate success
            return new JsonResult(new { success = true });
        }

        [HttpPost]
        public JsonResult OnPostSetCoverPath(string coverPath)
        {
            // Save the coverPath to the session
            HttpContext.Session.SetString("coverPath", coverPath);

            // Return a JSON result to indicate success
            return new JsonResult(new { success = true });
        }
    }
}
