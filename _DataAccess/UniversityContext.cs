using Microsoft.EntityFrameworkCore;
using University.Models.DataBaseModels;
using Microsoft.Extensions.Configuration;

namespace University._DataAccess
{
    public class UniversityContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public UniversityContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeacherGroup>()
                .HasKey(tg => new { tg.TeacherId, tg.GroupId });
        }


    }
}
