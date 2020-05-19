using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {

        }

        public DbSet<Phone> Phones { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<UserDTO> Users { get; set; }
    }
}
