using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Films.DAL.MsSqlServer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ActorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActorName = table.Column<string>(maxLength: 64, nullable: false),
                    ActorBirthday = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmDate = table.Column<DateTime>(type: "date", nullable: false),
                    FilmName = table.Column<string>(maxLength: 64, nullable: false),
                    FilmDescription = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.FilmId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(maxLength: 48, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "FilmActor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmActor", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FilmActor__Actor__3D5E1FD2",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "ActorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__FilmActor__FilmI__3C69FB99",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmId = table.Column<int>(nullable: false),
                    PhotoPath = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK__Photo__FilmId__49C3F6B7",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(maxLength: 64, nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK__Rating__FilmId__2F10007B",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreId = table.Column<int>(nullable: false),
                    FilmId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => x.Id);
                    table.ForeignKey(
                        name: "FK__FilmGenre__FilmI__5DCAEF64",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "FilmId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__FilmGenre__Genre__5CD6CB2B",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ActorId", "ActorBirthday", "ActorName" },
                values: new object[,]
                {
                    { 1, new DateTime(1952, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liam Neeson" },
                    { 20, new DateTime(1901, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rina Zelyonaya" },
                    { 19, new DateTime(1941, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vitaly Solomin" },
                    { 17, new DateTime(1992, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Boyega" },
                    { 16, new DateTime(1992, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daisy Ridley" },
                    { 15, new DateTime(1983, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam Driver" },
                    { 14, new DateTime(1945, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremy Bulloch" },
                    { 13, new DateTime(1935, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Prowse" },
                    { 12, new DateTime(1944, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peter Mayhew" },
                    { 11, new DateTime(1914, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alec Guinness" },
                    { 18, new DateTime(1935, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasily Livanov" },
                    { 9, new DateTime(1942, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harrison Ford" },
                    { 8, new DateTime(1951, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mark Hamill" },
                    { 7, new DateTime(1944, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ian McDiarmid" },
                    { 6, new DateTime(1944, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Frank Oz" },
                    { 5, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 4, new DateTime(1989, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jake Lloyd" },
                    { 3, new DateTime(1981, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Natalie Portman" },
                    { 2, new DateTime(1971, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ewan McGregor" },
                    { 10, new DateTime(1956, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carrie Fisher" }
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "FilmId", "FilmDate", "FilmDescription", "FilmName" },
                values: new object[,]
                {
                    { 10, new DateTime(1980, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "A cycle of Soviet television films from 1979-1986 directed by Igor Maslennikov, a film adaptation of the works of Arthur Conan Doyle about Sherlock Holmes. The cycle consists of five films (11 episodes with a total duration of 766 minutes},.", "Sherlock Holmes and Doctor Watson" },
                    { 8, new DateTime(2015, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thirty years after the Battle of Endor, a new threat has risen in the form of the First Order and the villainous Kylo Ren. Meanwhile, Rey, a young scavenger, discovers powers that will change her life -- and possibly save the galaxy.", "Star Wars: The Force Awakens" },
                    { 7, new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luke Skywalker leads a mission to rescue his friend Han Solo from the clutches of Jabba the Hutt, while the Emperor seeks to destroy the Rebellion once and for all with a second dreaded Death Star.", "Star Wars: Return of the Jedi" },
                    { 6, new DateTime(1980, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "While the Death Star has been destroyed, the battle between the Empire and the Rebel Alliance rages on...and the evil Darth Vader continues his relentless search for Luke Skywalker.", "Star Wars: The Empire Strikes Back" },
                    { 4, new DateTime(2005, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "The evil Darth Sidious enacts his final plan for unlimited power -- and the heroic Jedi Anakin Skywalker must choose a side.", "Star Wars: Revenge of the Sith" },
                    { 3, new DateTime(2002, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Following an assassination attempt on Senator Padmé Amidala, Jedi Knights Anakin Skywalker and Obi-Wan Kenobi investigate a mysterious plot that could change the galaxy forever.", "Star Wars: Attack of the Clones " },
                    { 2, new DateTime(1999, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "After a millennia, an ancient evil returns seeking revenge. Meanwhile, Jedi Knight Qui-Gon Jinn discovers Anakin Skywalker: a young slave boy unusually strong with the Force.", "Star Wars: The Phantom Menace" },
                    { 5, new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "With the planet-destroying power of the Death Star, the Empire looks to cement its grip on the galaxy. Meanwhile, farm boy Luke Skywalker rises to face his destiny.", "Star Wars: A New Hope" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 6, "Space opera" },
                    { 1, "Science fiction" },
                    { 2, "Film epic" },
                    { 3, "Detective film" },
                    { 4, "Action movie" },
                    { 5, "Adventures" },
                    { 7, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "FilmActor",
                columns: new[] { "Id", "ActorId", "FilmId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 21, 9, 6 },
                    { 22, 10, 6 },
                    { 23, 13, 6 },
                    { 24, 6, 6 },
                    { 19, 6, 6 },
                    { 25, 8, 7 },
                    { 26, 9, 7 },
                    { 28, 7, 7 },
                    { 29, 6, 7 },
                    { 30, 13, 7 },
                    { 31, 11, 7 },
                    { 32, 8, 8 },
                    { 33, 9, 8 },
                    { 34, 10, 8 },
                    { 35, 15, 8 },
                    { 36, 16, 8 },
                    { 38, 18, 10 },
                    { 39, 19, 10 },
                    { 40, 20, 10 },
                    { 20, 8, 6 },
                    { 18, 13, 5 },
                    { 27, 10, 7 },
                    { 9, 6, 3 },
                    { 8, 5, 3 },
                    { 5, 6, 2 },
                    { 10, 7, 3 },
                    { 17, 10, 5 },
                    { 4, 4, 2 },
                    { 7, 3, 3 },
                    { 3, 3, 2 },
                    { 11, 2, 4 },
                    { 12, 3, 4 },
                    { 13, 7, 4 },
                    { 14, 5, 4 },
                    { 15, 8, 5 },
                    { 16, 9, 5 },
                    { 2, 2, 2 },
                    { 6, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "FilmGenre",
                columns: new[] { "Id", "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 12, 3, 5 },
                    { 19, 4, 5 },
                    { 5, 2, 5 },
                    { 48, 8, 6 },
                    { 39, 7, 4 },
                    { 26, 5, 5 },
                    { 32, 6, 4 },
                    { 25, 5, 4 },
                    { 18, 4, 4 },
                    { 11, 3, 4 },
                    { 4, 2, 4 },
                    { 50, 10, 3 },
                    { 46, 8, 4 },
                    { 33, 6, 5 },
                    { 20, 4, 6 },
                    { 47, 8, 5 },
                    { 51, 10, 5 },
                    { 6, 2, 6 },
                    { 13, 3, 6 },
                    { 35, 6, 7 },
                    { 28, 5, 7 },
                    { 27, 5, 6 },
                    { 21, 4, 7 },
                    { 45, 8, 3 },
                    { 14, 3, 7 },
                    { 34, 6, 6 },
                    { 41, 7, 6 },
                    { 7, 2, 7 },
                    { 40, 7, 5 },
                    { 38, 7, 3 },
                    { 49, 8, 7 },
                    { 24, 5, 3 },
                    { 42, 7, 7 },
                    { 1, 2, 1 },
                    { 8, 3, 1 },
                    { 31, 6, 3 },
                    { 22, 5, 1 },
                    { 29, 6, 1 },
                    { 36, 7, 1 },
                    { 43, 8, 1 },
                    { 2, 2, 2 },
                    { 15, 4, 1 },
                    { 16, 4, 2 },
                    { 23, 5, 2 },
                    { 30, 6, 2 },
                    { 37, 7, 2 },
                    { 44, 8, 2 },
                    { 3, 2, 3 },
                    { 10, 3, 3 },
                    { 17, 4, 3 },
                    { 9, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Photo",
                columns: new[] { "PhotoId", "FilmId", "PhotoPath" },
                values: new object[,]
                {
                    { 1, 2, "Star Wars - The Phantom Menace.webp" },
                    { 2, 3, "Star Wars - Attack of the Clones.webp" },
                    { 3, 4, "Star Wars - Revenge of the Sith.jpeg" },
                    { 4, 5, "Star Wars - A New Hope.webp" },
                    { 6, 7, "Star Wars - Return of the Jedi.jpeg" },
                    { 7, 8, "Star Wars - The Force Awakens.webp" },
                    { 5, 6, "Star Wars - The Empire Strikes Back.jpeg" },
                    { 8, 10, "Sherlock Holmes and Doctor Watson.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "FilmId", "UserEmail" },
                values: new object[,]
                {
                    { 12, 6, "admin@gmail.com" },
                    { 15, 3, "vasya@gmail.com" },
                    { 13, 2, "vasya@gmail.com" },
                    { 10, 8, "admin@gmail.com" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmActor_ActorId",
                table: "FilmActor",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmActor_FilmId",
                table: "FilmActor",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_FilmId",
                table: "FilmGenre",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenreId",
                table: "FilmGenre",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Photo_FilmId",
                table: "Photo",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_FilmId",
                table: "Rating",
                column: "FilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmActor");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
