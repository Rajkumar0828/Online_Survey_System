using Microsoft.EntityFrameworkCore;
using Survey_System.Model;
namespace Survey_System.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }
        public DbSet<Response> Responses { get; set; }
        
        public DbSet<SurveyUser> Users { get; set; }

    }
}
