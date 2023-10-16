using System.ComponentModel.DataAnnotations;

namespace EmparejaTecWebApp.Model
{
    public class AppUser
    {
        [Key]
        public String email { get; set; }
        public String username { get; set; }
        public String summary { get; set; }
        public int age { get; set; }
        public int idGender { get; set; }
        public int idUserStatus { get; set; }
        public String avatarPath { get; set; }
        public String bannerPath { get; set; }
    }
}
