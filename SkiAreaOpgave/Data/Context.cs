using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SkiAreaOpgave.Models;

//using Microsoft.EntityFrameworkCore.Extensions;


namespace SkiAreaOpgave.Data
{
    public class Context : DbContext
    {
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\DABServer;Initial Catalog=SkiArea;Integrated Security=True;
                                Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;
                                MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SLOPE
            modelBuilder.Entity<Slope>().HasKey(s => s.Name);

            // AREA
            modelBuilder.Entity<Area>().HasKey(a => a.Name);

        }
        public DbSet<Slope> Slopes { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Skilift> Skilifts { get; set; }
        public DbSet<Skipass> Skipasses { get; set; }
        public DbSet<Guest> Guests { get; set; }

    }
}