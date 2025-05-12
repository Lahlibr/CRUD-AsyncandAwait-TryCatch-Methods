using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Employe
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Range(18,40)]
        public int Age { get; set; }
    }
}
