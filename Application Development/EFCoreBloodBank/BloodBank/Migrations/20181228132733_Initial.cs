using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBank.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dates = table.Column<DateTime>(nullable: false),
                    Descriptions = table.Column<string>(nullable: true),
                    Addresses = table.Column<string>(nullable: true),
                    Time_t = table.Column<DateTime>(nullable: false),
                    Medical_Incharge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.DonationId);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Info = table.Column<string>(nullable: true),
                    User_IdUser = table.Column<int>(nullable: false),
                    Donation_IdDonation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email_address = table.Column<string>(nullable: true),
                    Login_Name = table.Column<string>(nullable: true),
                    BloodType = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Medical_Report = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    User_IdUser = table.Column<int>(nullable: false),
                    Record_IdRecord = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => new { x.User_IdUser, x.Record_IdRecord });
                    table.UniqueConstraint("AK_Authentication_Record_IdRecord_User_IdUser", x => new { x.Record_IdRecord, x.User_IdUser });
                    table.ForeignKey(
                        name: "FK_Authentication_Record_Record_IdRecord",
                        column: x => x.Record_IdRecord,
                        principalTable: "Record",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Authentication_User_User_IdUser",
                        column: x => x.User_IdUser,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    User_IdUser = table.Column<int>(nullable: false),
                    Donation_IdDonation = table.Column<int>(nullable: false),
                    Informations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => new { x.User_IdUser, x.Donation_IdDonation });
                    table.UniqueConstraint("AK_Donors_Donation_IdDonation_User_IdUser", x => new { x.Donation_IdDonation, x.User_IdUser });
                    table.ForeignKey(
                        name: "FK_Donors_Donation_Donation_IdDonation",
                        column: x => x.Donation_IdDonation,
                        principalTable: "Donation",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donors_User_User_IdUser",
                        column: x => x.User_IdUser,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
