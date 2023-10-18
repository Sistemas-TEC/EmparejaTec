using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmparejaTecWebApp.Pages.Usuario
{
    public class Message
    {
        public string Sender { get; set; }
        public string Content { get; set; }
    }

    public class MessagesModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
