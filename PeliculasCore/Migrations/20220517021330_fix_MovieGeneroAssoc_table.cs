using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasCore.Migrations
{
    public partial class fix_MovieGeneroAssoc_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Character",
                table: "movie_genero_assoc");

            migrationBuilder.DropColumn(
                name: "ordery",
                table: "movie_genero_assoc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Character",
                table: "movie_genero_assoc",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ordery",
                table: "movie_genero_assoc",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
