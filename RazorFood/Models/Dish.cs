using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorFood.Models
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name= "Created On")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public String? Course { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string? Image { get; set; }
    }
}
