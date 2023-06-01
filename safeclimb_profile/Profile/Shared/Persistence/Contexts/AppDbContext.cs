using Go2Climb.API.Agencies.Domain.Models;
using Go2Climb.API.Customers.Domain.Models;
using Go2Climb.API.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Constrains
            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Customer>().HasKey(p => p.Id);
            builder.Entity<Customer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Customer>().Property(p => p.LastName).IsRequired().HasMaxLength(75);
            builder.Entity<Customer>().Property(p => p.Email).IsRequired().HasMaxLength(250);
            builder.Entity<Customer>().Property(p => p.PasswordHash).IsRequired().HasMaxLength(200);
            builder.Entity<Customer>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(11);
            builder.Entity<Customer>().Property(p => p.Photo);
            //Relationship
            
            //Agency Entity
            builder.Entity<Agency>().ToTable("Agencies");
            builder.Entity<Agency>().HasKey(p => p.Id);
            builder.Entity<Agency>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Agency>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Email).IsRequired();
            builder.Entity<Agency>().Property(p => p.PasswordHash).IsRequired().HasMaxLength(200);
            builder.Entity<Agency>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Entity<Agency>().Property(p => p.Description).IsRequired().HasMaxLength(200);
            builder.Entity<Agency>().Property(p => p.Location).IsRequired().HasMaxLength(50);
            builder.Entity<Agency>().Property(p => p.Ruc).IsRequired();
            builder.Entity<Agency>().Property(p => p.Photo);
            builder.Entity<Agency>().Property(p => p.Score);
            //Activity Entity

            builder.UseSnakeCaseNamingConventions();
        }
        
    }
}