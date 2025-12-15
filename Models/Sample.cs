using System;
using System.ComponentModel.DataAnnotations;

namespace AVDetectionTest.Models
{
    public class Sample
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FileName { get; set; }
        
        [Required]
        public string Sha256Hash { get; set; }
        
        public string Description { get; set; }
        
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
        
        public string Category { get; set; } = "Unknown";
    }
}
