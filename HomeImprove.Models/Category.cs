using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeImpr.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ime je neophodno unijeti!")]
        [MaxLength(30, ErrorMessage ="Maksimalna dužina imena kategorije je 30")]
        [DisplayName("Ime kategorije")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Neophodno je unijeti ispravan redoslijed kategorije!")]
        [DisplayName("Redoslijed prikaza")]
        [Range(1, 100, ErrorMessage="Redoslijed mora biti između 1 i 100")]
        public int? DisplayOrder { get; set; }
    }
}
