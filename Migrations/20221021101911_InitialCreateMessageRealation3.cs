using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class InitialCreateMessageRealation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_smartBoxes_SmartBoxId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SmarBoxId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "SmartBoxId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_smartBoxes_SmartBoxId",
                table: "Messages",
                column: "SmartBoxId",
                principalTable: "smartBoxes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_smartBoxes_SmartBoxId",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "SmartBoxId",
                table: "Messages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SmarBoxId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_smartBoxes_SmartBoxId",
                table: "Messages",
                column: "SmartBoxId",
                principalTable: "smartBoxes",
                principalColumn: "Id");
        }
    }
}
