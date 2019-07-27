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
        public DbSet<User_Donation> Donors { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<Record> Record { get; set; }
        public DbSet<User_Record> Authentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(s => s.UserId);

            modelBuilder.Entity<Record>()
               .HasKey(s => s.RecordId);

            modelBuilder.Entity<Donation>()
               .HasKey(s => s.DonationId);

            modelBuilder.Entity<User_Donation>()
               .HasKey(c => new {c.User_IdUser,c.Donation_IdDonation });

            modelBuilder.Entity<User_Record>()
                .HasKey(l => new { l.User_IdUser, l.Record_IdRecord});
     
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = tcp:bloodbank.database.windows.net, 1433; Initial Catalog = BloodBank; Persist Security Info = False; User ID = {ID}; Password = {password}; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }

    }

}
