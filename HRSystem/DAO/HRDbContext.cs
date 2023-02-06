using Microsoft.EntityFrameworkCore;
namespace HRSystem.HRDbContext
{
    public class HRDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public HRDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(_configuration.GetConnectionString("ConnectionStrings"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            //fluent APIs
        }

        //entities
    }
}
