using Microsoft.EntityFrameworkCore;

namespace AVDetectionTest.Models
{
    public class Dataset : DbContext
    {
        public DbSet<Sample> Samples { get; set; }
        public DbSet<ScanResult> ScanResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=avtest.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sample>()
                .HasIndex(s => s.Sha256Hash)
                .IsUnique();

            modelBuilder.Entity<ScanResult>()
                .HasOne<Sample>()
                .WithMany()
                .HasForeignKey(sr => sr.SampleId);
        }
    }
}
