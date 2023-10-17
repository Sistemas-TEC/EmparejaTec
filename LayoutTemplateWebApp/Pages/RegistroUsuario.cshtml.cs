using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Extensions;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmparejaTecWebApp.Pages
{
    public class RegistroUsuarioModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IEnumerable<Interest> Interests { get; set; }

        public IEnumerable<Interest> SelectedInterests { get; set; }

        [BindProperty]
        public AppUser AppUser { get; set; }

        [BindProperty]
        public List<CheckBoxItem> LookingFor { get; set; }

        [BindProperty]
        public int SelectedGender { get; set; }

        [BindProperty]
        public List<RadioButtonItem> Genders { get; set; }

        [BindProperty]
        public List<CheckBoxItem> AttractedTo { get; set; }

        public string role { get; set; }
        public RegistroUsuarioModel(ApplicationDBContext db)
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
            if (Interests == null)
            {
                Interests = _db.Interest.ToList();
                SelectedInterests = new List<Interest>();
                HttpContext.Session.SetObjectAsJson("interests", Interests);
                HttpContext.Session.SetObjectAsJson("selectedInterests", SelectedInterests);
            }

            LookingFor = new List<CheckBoxItem>
            {
                new CheckBoxItem { Label = "Amistad", Value = 1 },
                new CheckBoxItem { Label = "Romance", Value = 2 }
            };
            Genders = new List<RadioButtonItem>
            {
                new RadioButtonItem { Label = "Femenino", Value = 1 },
                new RadioButtonItem { Label = "Masculino", Value = 2 },
                new RadioButtonItem { Label = "Otro", Value = 3 }
            };
            AttractedTo = new List<CheckBoxItem>
            {
                new CheckBoxItem { Label = "Femenino", Value = 1 },
                new CheckBoxItem { Label = "Masculino", Value = 2 },
                new CheckBoxItem { Label = "Otro", Value = 3 }
            };

        }

        public void OnPost(AppUser appUser)
        {

            // Get selected interests from the session
            this.SelectedInterests = HttpContext.Session.GetObjectFromJson<List<Interest>>("selectedInterests");

            // Now you can access the selected checkbox items in lookingForSelected
            var lookingForSelected = LookingFor.Where(item => item.IsSelected).ToList();

            // Access the selected gender
            var genderSelected = SelectedGender;

            var attractedToSelected = AttractedTo.Where(item => item.IsSelected).ToList();

            //Compose the AppUser object

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
                SelectedInterests = SelectedInterests.Append(newInterest);
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
                Interests = Interests.Append(interestToRemove);
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

    public class CheckBoxItem
    {
        public int Value { get; set; }
        public string Label { get; set; }
        public bool IsSelected { get; set; }
    }

    public class RadioButtonItem
    {
        public int Value { get; set; }
        public string Label { get; set; }
    }
}
