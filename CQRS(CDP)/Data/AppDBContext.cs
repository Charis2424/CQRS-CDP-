using CQRS_CDP_.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_CDP_.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext>options) : base(options)
        {

        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Candidate>()
        //        .HasMany(c => c.Certificates)
        //        .WithMany(c => c.Candidates);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
