using System.ComponentModel.DataAnnotations;

namespace EmparejaTecWebApp.Model
{
    public class UserPossibleMatch
    {
        [Key]
        public int idUserPossibleMatch { get; set; }
        public string idUserLogged { get; set; }
        public string idPossibleMatch { get; set; }
    }
}
