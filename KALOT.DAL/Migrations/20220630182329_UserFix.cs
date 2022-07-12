using Microsoft.EntityFrameworkCore.Migrations;

namespace KALOT.DAL.Migrations
{
    public partial class UserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Tabs");

            migrationBuilder.AlterColumn<string>(
                name: "User_ID",
                table: "Tabs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tabs_User_ID",
                table: "Tabs",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabs_AspNetUsers_User_ID",
                table: "Tabs",
                column: "User_ID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabs_AspNetUsers_User_ID",
                table: "Tabs");

            migrationBuilder.DropIndex(
                name: "IX_Tabs_User_ID",
                table: "Tabs");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "User_ID",
                table: "Tabs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "User",
                table: "Tabs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
