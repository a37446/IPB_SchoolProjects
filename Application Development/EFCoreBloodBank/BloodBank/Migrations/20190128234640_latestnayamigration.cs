using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBank.Migrations
{
    public partial class latestnayamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Donation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donation_UserID",
                table: "Donation",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_User_UserID",
                table: "Donation",
                column: "UserID",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donation_User_UserID",
                table: "Donation");

            migrationBuilder.DropIndex(
                name: "IX_Donation_UserID",
                table: "Donation");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Donation");

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
    }
}
