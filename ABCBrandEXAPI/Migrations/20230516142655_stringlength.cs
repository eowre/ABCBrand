using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABCBrandEXAPI.Migrations
{
    public partial class stringlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Cartons",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "Cartons",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "artNum",
                table: "Cartons",
                newName: "ArtNum");

            migrationBuilder.AlterColumn<string>(
                name: "ArtNum",
                table: "Cartons",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Cartons",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Cartons",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ArtNum",
                table: "Cartons",
                newName: "artNum");

            migrationBuilder.AlterColumn<string>(
                name: "artNum",
                table: "Cartons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);
        }
    }
}
