using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderQueueSystem.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Processado",
                table: "tb_pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Processado",
                table: "tb_pedidos");
        }
    }
}
