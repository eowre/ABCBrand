using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ABCBrandEXAPI.Models
{
    public class Carton
    {

        public int Id { get; set; }
        [Required]
        [RegularExpression("OK|NOTOK|ok|notok")]
        public string Status { get; set; }
 
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Required]
        [StringLength(32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class CartonDTO
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("OK|NOTOK|ok|notok")]

        public string Status { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Required]
        [StringLength(32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
    public class CartonDetailsDTO
    {
        [Required]
        [RegularExpression("OK|NOTOK|ok|notok")]

        public string Status { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Required]
        [StringLength(32)]
        public string ArtNum { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
