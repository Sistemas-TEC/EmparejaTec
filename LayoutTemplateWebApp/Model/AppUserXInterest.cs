using System.ComponentModel.DataAnnotations;

namespace EmparejaTecWebApp.Model
{
    public class AppUserXInterest
    {
        [Key]
        public int idAppUserXInterest { get; set; }
        [Required]
        public String email { get; set; }
        [Required]
        public int idInterest { get; set; }
    }
}
