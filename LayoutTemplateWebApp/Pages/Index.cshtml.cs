using EmparejaTecWebApp.Data;
using EmparejaTecWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace EmparejaTecWebApp.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        public UserAPIModel User { get; set; }

        public string RawJsonData { get; set; }

        public AppUser AppUser { get; set; }

        private readonly IHttpClientFactory _clientFactory;

        private readonly ApplicationDBContext _db;

        public IndexModel(IHttpClientFactory clientFactory, ApplicationDBContext db)
        {
            _clientFactory = clientFactory;
            _db = db;
        }
        public async Task OnGetAsync(string email)
        {

            string id = HttpContext.Session.GetString("email");
            if (string.IsNullOrEmpty(email))
            {
                //check for session
                if (string.IsNullOrEmpty(id))
                {
                    Email = "Default or Anonymous User";
                    Response.Redirect("/ErrorPage");
                    return;
                }
                // Now make the asynchronous call to the external API
                else if (HttpContext.Session.GetString("role") == "7415")
                {
                    Response.Redirect("/Usuario/Index");
                    return;
                }


            }
            else
            {
                Email = email;
                var client = _clientFactory.CreateClient();
                var response = await client.GetAsync("http://sistema-tec.somee.com/api/users/" + Email);

                if (response.IsSuccessStatusCode)
                {

                    // Attempt to deserialize the data
                    try
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        RawJsonData = data; // Use a logging framework or another method to inspect 'data'
                        User = JsonSerializer.Deserialize<UserAPIModel>(data);

                        HttpContext.Session.SetString("SessionKey", Guid.NewGuid().ToString());
                        HttpContext.Session.SetString("id", User.Id.ToString());
                        HttpContext.Session.SetString("email", User.Email.ToString());

                        for (int i = 0; i < User.ApplicationRoles.Count; i++)
                        {
                            if (User.ApplicationRoles[i].ApplicationId == 1) // eventually has to be changed
                            {
                                if (User.ApplicationRoles[i].Id == 1) // eventually has to be changed
                                {
                                    HttpContext.Session.SetString("role", "7415"); //Normal requester user
                                    break;
                                }
                            }
                        }
                    }
                    catch (JsonException ex)
                    {
                        // Log or output the deserialization error
                        RawJsonData = $"Error deserializing data: {ex.Message}";
                    }
                }
                else
                {
                    // Log or output the unsuccessful status code
                    RawJsonData = $"Error: {response.StatusCode}";
                }
            }
            // Consultar si el usuario existe en la base de datos con AppUser
            AppUser = _db.AppUser.Find(Email);
            if (AppUser == null)
            {
                Response.Redirect("/RegistroUsuario");
            }
            else
            {
                HttpContext.Session.SetString("username", AppUser.username.ToString());
                HttpContext.Session.SetString("avatarPath", AppUser.avatarPath.ToString());
                Response.Redirect("/Usuario/Index");
            }

        }

    }
}
