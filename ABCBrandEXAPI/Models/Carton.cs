using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ABCBrandEXAPI.Models
{
    public class Carton
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class CartonDTO
    {
        public int Id { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class CartonDetailsDTO
    {
        [Required]
        public string Status { get; set; }
        [Required]
        [StringLength(32, MinimumLength = 32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }

}
