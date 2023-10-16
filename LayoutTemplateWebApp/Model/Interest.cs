using System.ComponentModel.DataAnnotations;

namespace EmparejaTecWebApp.Model
{
    public class Interest
    {
        [Key]
        public int idInterest { get; set; }

        public string interest { get; set; }
    }
}
