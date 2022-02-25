using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestApplication.Model
{
    public class Country
    {
        public long Id { get; set; }
        
        [MaxLength(100)]
        [Required]
        public string? Name { get; set; }

        public List<City> Cities { get; } = new();
    }
}