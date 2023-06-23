using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BulkyWeb_RazorTemp.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(30)] //for server side validation
        [DisplayName("Category name")] //for displaying the name in the view
        public string Name { get; set; }

        [DisplayName("Display order")]
        [Range(1, 100, ErrorMessage = "Display order must be between 1-100")]
        public int DisplayOrder { get; set; }
    }
}
