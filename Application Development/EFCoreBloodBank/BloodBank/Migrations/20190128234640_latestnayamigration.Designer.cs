﻿// <auto-generated />
using System;
using EFCoreBloodBank;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BloodBank.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20190128234640_latestnayamigration")]
    partial class latestnayamigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BloodBank.Classes.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImage");

                    b.Property<string>("Title");

                    b.Property<string>("details");

                    b.HasKey("NewsId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addresses");

                    b.Property<DateTime>("Dates");

                    b.Property<string>("Descriptions");

                    b.Property<string>("Medical_Incharge");

                    b.Property<DateTime>("Time_t");

                    b.Property<int?>("UserID");

                    b.HasKey("DonationId");

                    b.HasIndex("UserID");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Donation_IdDonation");

                    b.Property<string>("Info");

                    b.Property<int>("User_IdUser");

                    b.HasKey("RecordId");

                    b.ToTable("Record");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BloodType");

                    b.Property<string>("Email_address");

                    b.Property<string>("Login_Name");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("Telephone");

                    b.Property<bool>("isAdmin");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User_Record", b =>
                {
                    b.Property<int>("User_IdUser");

                    b.Property<int>("Record_IdRecord");

                    b.HasKey("User_IdUser", "Record_IdRecord");

                    b.HasAlternateKey("Record_IdRecord", "User_IdUser");

                    b.ToTable("Authentication");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.Donation", b =>
                {
                    b.HasOne("EFCoreBloodBank.Classes.User", "User")
                        .WithMany("donations")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User_Record", b =>
                {
                    b.HasOne("EFCoreBloodBank.Classes.Record", "Record")
                        .WithMany("User_Records")
                        .HasForeignKey("Record_IdRecord")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreBloodBank.Classes.User", "User")
                        .WithMany("User_Records")
                        .HasForeignKey("User_IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
