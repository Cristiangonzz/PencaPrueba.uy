using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordPenca.Backoffice.Migrations
{
    /// <inheritdoc />
    public partial class IniciarPenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Historial",
                table: "ChatMensajes");

            migrationBuilder.AlterColumn<string>(
                name: "RespuestaMensaje",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RespuestaMensaje",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Historial",
                table: "ChatMensajes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
