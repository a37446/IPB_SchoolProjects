using BloodBank.Classes;
using EFCoreBloodBank.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreBloodBank
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(s => s.UserId);

            modelBuilder.Entity<Record>()
               .HasKey(s => s.RecordId);

            modelBuilder.Entity<News>()
              .HasKey(s => s.NewsId);

            modelBuilder.Entity<Donation>()
               .HasKey(s => s.DonationId);
        
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:bloodbank.database.windows.net,1433;Initial Catalog=BloodBank;Persist Security Info=False;User ID=bloodbank;Password=Ratoragat111;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

    }

}