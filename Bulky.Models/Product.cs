using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string ISBN { get; set; }
        
        [Required]
        [Range(0, 10000)]
        [Display(Name = "List Price")]
        public Double ListPrice { get; set; }
        
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(0, 10000)]
        public Double Price { get; set; }
        
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(0, 10000)]
        public Double Price50 { get; set; }
        
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(0, 10000)]
        public Double Price100 { get; set; }
        
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }
        
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;
    }
}
