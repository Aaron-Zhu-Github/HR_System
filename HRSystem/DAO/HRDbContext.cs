using System;
using System.Security;
using Microsoft.EntityFrameworkCore;
using HRSystem.Models;

namespace HRSystem.DAO
{
	public class HRDbContext:DbContext
	{
        private readonly IConfiguration _configuration;

        public HRDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(_configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent APIs
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<Address>().ToTable("Address");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}

