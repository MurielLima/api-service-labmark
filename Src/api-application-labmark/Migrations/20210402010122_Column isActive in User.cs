using Microsoft.EntityFrameworkCore.Migrations;

namespace Labmark.Migrations
{
    public partial class ColumnisActiveinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoAcesso",
                schema: "LAB",
                table: "Pessoa",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Resultado",
                schema: "LAB",
                table: "ContagemMBLB",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Leitura",
                schema: "LAB",
                table: "ContagemMBLB",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                schema: "LAB",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                schema: "LAB",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "TipoAcesso",
                schema: "LAB",
                table: "Pessoa",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<double>(
                name: "Resultado",
                schema: "LAB",
                table: "ContagemMBLB",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "Leitura",
                schema: "LAB",
                table: "ContagemMBLB",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
