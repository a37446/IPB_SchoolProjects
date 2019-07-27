using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodBank.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentication");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
