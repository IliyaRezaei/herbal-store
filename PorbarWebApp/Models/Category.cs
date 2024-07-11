using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PorbarWebApp.Models
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("نام دسته بندی محصول")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
