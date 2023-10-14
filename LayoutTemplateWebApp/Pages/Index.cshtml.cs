using LayoutTemplateWebApp.Data;
using LayoutTemplateWebApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LayoutTemplateWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Student Student { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Student = _db.Student.Find("thecsarbeat@estudiantec.cr");
        }
        public string SelectedImage { get; set; }
    }
}
