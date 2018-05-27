using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL
{
    public class DriverSystemContext : DbContext
    {

        public DriverSystemContext(DbContextOptions<DriverSystemContext> options) : base (options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => new {u.email, u.userName}).IsUnique();
        }

        public DbSet<Translation> Translations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Invoice> Invoices { get; set; }      
        public DbSet<User> Users { get; set; }
        public DbSet<Row> Row { get; set; }
    }
}
