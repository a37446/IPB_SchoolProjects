﻿// <auto-generated />
using System;
using EFCoreBloodBank;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCoreBloodBank.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20181108003818_BloodBank_Migration")]
    partial class BloodBank_Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.HasKey("DonationId");

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

                    b.Property<string>("Email_address");

                    b.Property<string>("Login_Name");

                    b.Property<string>("Medical_Report");

                    b.Property<string>("Password");

                    b.Property<string>("Telephone");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User_Donation", b =>
                {
                    b.Property<int>("User_IdUser");

                    b.Property<int>("Donation_IdDonation");

                    b.Property<string>("Informations");

                    b.HasKey("User_IdUser", "Donation_IdDonation");

                    b.HasAlternateKey("Donation_IdDonation", "User_IdUser");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User_Record", b =>
                {
                    b.Property<int>("User_IdUser");

                    b.Property<int>("Record_IdRecord");

                    b.HasKey("User_IdUser", "Record_IdRecord");

                    b.HasAlternateKey("Record_IdRecord", "User_IdUser");

                    b.ToTable("Authentication");
                });

            modelBuilder.Entity("EFCoreBloodBank.Classes.User_Donation", b =>
                {
                    b.HasOne("EFCoreBloodBank.Classes.Donation", "Donation")
                        .WithMany("User_Donations")
                        .HasForeignKey("Donation_IdDonation")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFCoreBloodBank.Classes.User", "User")
                        .WithMany("User_Donations")
                        .HasForeignKey("User_IdUser")
                        .OnDelete(DeleteBehavior.Cascade);
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
