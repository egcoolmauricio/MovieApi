using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeliculasCore.Migrations
{
    public partial class MovieActorAssoc_MovieGeneroAssoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movie_actor_assoc",
                columns: table => new
                {
                    actor_id = table.Column<int>(type: "int", nullable: false),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ordery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_actor_assoc", x => new { x.movie_id, x.actor_id });
                    table.ForeignKey(
                        name: "FK_movie_actor_assoc_Actores_actor_id",
                        column: x => x.actor_id,
                        principalTable: "Actores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movie_actor_assoc_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movie_genero_assoc",
                columns: table => new
                {
                    genero_id = table.Column<int>(type: "int", nullable: false),
                    movie_id = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ordery = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_genero_assoc", x => new { x.movie_id, x.genero_id });
                    table.ForeignKey(
                        name: "FK_movie_genero_assoc_Generos_genero_id",
                        column: x => x.genero_id,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movie_genero_assoc_Movies_movie_id",
                        column: x => x.movie_id,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movie_actor_assoc_actor_id",
                table: "movie_actor_assoc",
                column: "actor_id");

            migrationBuilder.CreateIndex(
                name: "IX_movie_genero_assoc_genero_id",
                table: "movie_genero_assoc",
                column: "genero_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movie_actor_assoc");

            migrationBuilder.DropTable(
                name: "movie_genero_assoc");
        }
    }
}
