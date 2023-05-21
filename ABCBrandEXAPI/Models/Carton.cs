using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ABCBrandEXAPI.Models
{
    public class Carton //general model definition for the carton
    {

        public int Id { get; set; }
        [Required]
        [RegularExpression("OK|NOTOK|ok|notok")]
        public string Status { get; set; } //status filed is restricted by the above regex
 
        [RegularExpression("^[a-zA-Z0-9]*$")]
        [Required]
        [StringLength(32)]
        public string ArtNum { get; set; } // article number also has a restricting regex, and max string length
        [Required]
        public int Quantity { get; set; }
    }
    public class CartonDTO // building a DTO for GET methods to as hide database layer, contains the same restrictions as carton
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
    public class CartonDetailsDTO // building dto for Post method
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
