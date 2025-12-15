using System;
using System.ComponentModel.DataAnnotations;

namespace AVDetectionTest.Models
{
    public class ScanResult
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int SampleId { get; set; }
        
        [Required]
        public string AntivirusName { get; set; }
        
        public bool Detected { get; set; }
        
        public string DetectionName { get; set; }
        
        public DateTime ScanDate { get; set; } = DateTime.UtcNow;
        
        public double ScanDurationMs { get; set; }
    }
}
