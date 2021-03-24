using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GarbageCollector.Models;

namespace GarbageCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                  new IdentityRole
                  {
                      Name = "Admin",
                      NormalizedName = "ADMIN"
                  }
                );
        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee> Role { get; set; }

    }
}
