namespace HRSystem.DAO
{
    using Microsoft.EntityFrameworkCore;

    public class HRDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public HRDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            _ = option.UseSqlServer(_configuration.GetConnectionString("ConnectionStrings"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent APIs
        }

        //entities
    }
}
