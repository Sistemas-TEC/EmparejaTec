using System.ComponentModel.DataAnnotations;

namespace EmparejaTecWebApp.Model
{
    public class AppUser
    {
        [Key]
        public String email { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public String username { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        public String summary { get; set; }

        [Required(ErrorMessage = "La edad es requerida")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "La edad debe ser un número")]
        public int age { get; set; }

        public int idGender { get; set; }

        public int idUserStatus { get; set; }

        public String avatarPath { get; set; }

        public String bannerPath { get; set; }
    }
}
