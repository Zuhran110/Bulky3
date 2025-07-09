using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 255)]
        public int DisplayOrder { get; set; }
        
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
        
        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}