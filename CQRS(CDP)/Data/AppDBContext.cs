using CQRS_CDP_.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_CDP_.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<Candidate> candidates { get; set; }
        public DbSet<Certificate> certificates { get; set; }
        public DbSet<Exam> exams { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext>options) : base(options)
        {

        }
        
    }
}
