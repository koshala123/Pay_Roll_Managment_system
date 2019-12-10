using Microsoft.EntityFrameworkCore.Migrations;

namespace Pay_Roll_Managment_System.Migrations
{
    public partial class AddedPositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Position_PoistionId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PoistionId",
                table: "Employees",
                column: "PoistionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PoistionId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "Position",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Position",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Position_PoistionId",
                table: "Employees",
                column: "PoistionId",
                principalTable: "Position",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
