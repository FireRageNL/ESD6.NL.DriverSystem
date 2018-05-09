using System;
using Microsoft.EntityFrameworkCore;
using ESD6NL.DriverSystem.Entities;

namespace ESD6NL.DriverSystem.DAL
{
    public class DriverSystemContext : DbContext
    {
        public DriverSystemContext(DbContextOptions<DriverSystemContext> options) : base (options)
        {
        }
        public DbSet<Translation> Translations { get; set; }
    }
}
