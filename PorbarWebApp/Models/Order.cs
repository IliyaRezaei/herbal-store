using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [DisplayName("کاربر")]
        public User User { get; set; }
        [Required]
        public int ProductId { get; set; }
        [DisplayName("محصول")]
        public Product Product { get; set; }
        [Required]
        [DisplayName("تعداد محصول")]
        public int ProductQuantity { get; set; }
        [DisplayName("فروخته شده")]
        public bool? IsSold { get; set; }
        [DisplayName("زمان خرید")]
        public DateTime? DateTimeBought { get; set; }
    }
}
