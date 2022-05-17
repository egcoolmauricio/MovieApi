using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasCore.Migrations
{
    public partial class fix_MovieActorAssoc_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ordery",
                table: "movie_actor_assoc",
                newName: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Order",
                table: "movie_actor_assoc",
                newName: "ordery");
        }
    }
}
