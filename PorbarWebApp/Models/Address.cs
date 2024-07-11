using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("شهر")]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("خیابان اصلی")]

        public string MainStreet { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("کوچه")]

        public string Alley { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("کد پستی")]

        public string PostalCode { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("شماره پلاک")]

        public string PlateNumber { get; set; }
        [Required]
        [MaxLength(5)]//some unit numbers contain digits and numbers
        [DisplayName("شماره واحد")]

        public string UnitNumber { get; set; }
    }
}
