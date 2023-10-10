using System.ComponentModel.DataAnnotations;

namespace LayoutTemplateWebApp.Model
{
    public class Student
    {
        [Key]
        public String email { get; set; }
        [Required]
        public String pass { get; set; }

        public int studentId { get; set; }
    }
}
