using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("اسم محصول")]

        public string Name { get; set; }
        [Required]
        [MaxLength(2000)]
        [DisplayName("توضیحات")]

        public string Description { get; set; }
        [Required]
        [DisplayName("تصویر")]
        public string ImageUrl { get; set; }
        [Required]
        [DisplayName("قیمت")]

        public int Price { get; set; }
        [Required]
        [DisplayName("مقدار")]

        public int Quantity { get; set; }
        [Required]

        public int CategoryId { get; set; }
        [DisplayName("دسته بندی")]
        public Category? Category { get; set; }
    }
}
