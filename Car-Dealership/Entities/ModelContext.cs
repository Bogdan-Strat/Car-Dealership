using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entities
{
    public class ModelContext : IdentityDbContext<User,Role,string,IdentityUserClaim<string>,UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public DbSet<Model> Model { get; set; }
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword

        public DbSet<Specifications> Specifications { get; set; }
        
        public DbSet<Producer> Producer { get; set; }
        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder
                 .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                 .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Cars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
         }*/
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Model>()
                .HasOne(a => a.Specifications)
                .WithOne(aa => aa.Model)
                .HasForeignKey<Specifications>(c => c.IdModel);

            builder.Entity<Producer>()
                .HasMany(a => a.Model)
                .WithOne(b => b.Producer);

            builder.Entity<Contract>()
                .HasKey(c => new { c.IdModel, c.IdCustomer });

            builder.Entity<Contract>()
                .HasOne<Model>(a => a.Model)
                .WithMany(b => b.Transaction)
                .HasForeignKey(c => c.IdModel);

            builder.Entity<Contract>()
                .HasOne<Customers>(a => a.Customers)
                .WithMany(b => b.Transaction)
                .HasForeignKey(c => c.IdCustomer);
        }
    }
}
