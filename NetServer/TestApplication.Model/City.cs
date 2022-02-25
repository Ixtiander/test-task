using System.ComponentModel.DataAnnotations;

namespace TestApplication.Model
{
    public class City
    {
        public long Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }
        
        public long CountryId { get; set; }
    }
}