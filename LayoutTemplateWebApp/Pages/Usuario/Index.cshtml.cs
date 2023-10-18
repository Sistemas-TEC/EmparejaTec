using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Extensions;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmparejaTecWebApp.Pages.Usuario
{
    public class IndexModel : PageModel
    {
        public string role { get; set; }

        public AppUser CurrentDisplayedAppUser { get; set; }

        public List<Interest> CurrentDisplayedInterests { get; set; } = new List<Interest>();

        private readonly ApplicationDBContext _db;

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            // Get role from session
            role = HttpContext.Session.GetString("role");
            if (role != "7415")
            {
                Response.Redirect("/ErrorPage");
                return;
            }

            // Retrieve the logged-in user's email from the session
            var loggedUserEmail = HttpContext.Session.GetString("email");

            // Check if the email exists in the session
            if (string.IsNullOrEmpty(loggedUserEmail))
            {
                // Handle the case where the email isn't set in the session (you might want to redirect or show an error)
                Response.Redirect("/ErrorPage");
                return;
            }

            // Find the first possible match for the logged-in user
            var firstPossibleMatch = _db.UserPossibleMatch
                .FirstOrDefault(upm => upm.idUserLogged == loggedUserEmail);

            // If there's a possible match, get their profile information from AppUser table
            if (firstPossibleMatch != null)
            {
                CurrentDisplayedAppUser = _db.AppUser
                    .FirstOrDefault(user => user.email == firstPossibleMatch.idPossibleMatch);

                assignInterests();

                // Save the CurrentDisplayedAppUser to session
                HttpContext.Session.SetObjectAsJson("CurrentDisplayedAppUser", CurrentDisplayedAppUser);
            }
        }

        public void assignInterests()
        {
            if (CurrentDisplayedAppUser == null)
            {
                return;
            }
            var email = CurrentDisplayedAppUser.email;
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
                        CurrentDisplayedInterests.Add(interest);
                    }
                }
            }
        }

        private async Task DeleteCurrentDisplayedAppUser(string email)
        {
            var parameter = new SqlParameter("@email", email);
            await _db.Database.ExecuteSqlRawAsync("EXEC sp_DeleteUserPossibleMatch @email", parameter);
        }

        [HttpPost]
        public async Task<JsonResult> OnPostAccept(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                // Handle the case where the email isn't set in the session (you might want to return a failure in the JSON)
                return new JsonResult(new { success = false, message = "Email not found in session." });
            }

            await DeleteCurrentDisplayedAppUser(email);

            return new JsonResult(new { success = true });
        }

        [HttpPost]
        public async Task<JsonResult> OnPostReject(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                // Handle the case where the email isn't set in the session (you might want to return a failure in the JSON)
                return new JsonResult(new { success = false, message = "Email not found in session." });
            }

            await DeleteCurrentDisplayedAppUser(email);

            return new JsonResult(new { success = true });
        }
    }
}
