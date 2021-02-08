using Microsoft.EntityFrameworkCore.Migrations;

namespace Swellow.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOld = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Librarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathPicture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Librarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Serieses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serieses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOriginal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PathDirectory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdLibrary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PathDirectory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PathDirectory_Librarys_IdLibrary",
                        column: x => x.IdLibrary,
                        principalTable: "Librarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleOriginZh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlotOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Score = table.Column<byte>(type: "tinyint", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathFanart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PathPoster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdSeries = table.Column<int>(type: "int", nullable: false),
                    IdLibrary = table.Column<int>(type: "int", nullable: false),
                    IdDouban = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTmdb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdImdb = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Librarys_IdLibrary",
                        column: x => x.IdLibrary,
                        principalTable: "Librarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videos_Serieses_IdSeries",
                        column: x => x.IdSeries,
                        principalTable: "Serieses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    NoEpisode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propertys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeMovie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpisodeMovie_Videos_IdMovie",
                        column: x => x.IdMovie,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeTv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTv = table.Column<int>(type: "int", nullable: false),
                    NoSeason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoEpisode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Propertys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeTv", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EpisodeTv_Videos_IdTv",
                        column: x => x.IdTv,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoActors",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdCast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoActors", x => new { x.IdVideo, x.IdCast });
                    table.ForeignKey(
                        name: "FK_VideoActors_Casts_IdCast",
                        column: x => x.IdCast,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoActors_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoDirectors",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdCast = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoDirectors", x => new { x.IdVideo, x.IdCast });
                    table.ForeignKey(
                        name: "FK_VideoDirectors_Casts_IdCast",
                        column: x => x.IdCast,
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoDirectors_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoGenres",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGenres", x => new { x.IdVideo, x.IdGenre });
                    table.ForeignKey(
                        name: "FK_VideoGenres_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoGenres_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoPublishers",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdPublisher = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoPublishers", x => new { x.IdVideo, x.IdPublisher });
                    table.ForeignKey(
                        name: "FK_VideoPublishers_Publishers_IdPublisher",
                        column: x => x.IdPublisher,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoPublishers_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoStudios",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdStudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoStudios", x => new { x.IdVideo, x.IdStudio });
                    table.ForeignKey(
                        name: "FK_VideoStudios_Studios_IdStudio",
                        column: x => x.IdStudio,
                        principalTable: "Studios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoStudios_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoTags",
                columns: table => new
                {
                    IdVideo = table.Column<int>(type: "int", nullable: false),
                    IdTag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTags", x => new { x.IdVideo, x.IdTag });
                    table.ForeignKey(
                        name: "FK_VideoTags_Tags_IdTag",
                        column: x => x.IdTag,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoTags_Videos_IdVideo",
                        column: x => x.IdVideo,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeMovie_IdMovie",
                table: "EpisodeMovie",
                column: "IdMovie");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeTv_IdTv",
                table: "EpisodeTv",
                column: "IdTv");

            migrationBuilder.CreateIndex(
                name: "IX_PathDirectory_IdLibrary",
                table: "PathDirectory",
                column: "IdLibrary");

            migrationBuilder.CreateIndex(
                name: "IX_VideoActors_IdCast",
                table: "VideoActors",
                column: "IdCast");

            migrationBuilder.CreateIndex(
                name: "IX_VideoDirectors_IdCast",
                table: "VideoDirectors",
                column: "IdCast");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGenres_IdGenre",
                table: "VideoGenres",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_VideoPublishers_IdPublisher",
                table: "VideoPublishers",
                column: "IdPublisher");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_IdLibrary",
                table: "Videos",
                column: "IdLibrary");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_IdSeries",
                table: "Videos",
                column: "IdSeries");

            migrationBuilder.CreateIndex(
                name: "IX_VideoStudios_IdStudio",
                table: "VideoStudios",
                column: "IdStudio");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTags_IdTag",
                table: "VideoTags",
                column: "IdTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodeMovie");

            migrationBuilder.DropTable(
                name: "EpisodeTv");

            migrationBuilder.DropTable(
                name: "PathDirectory");

            migrationBuilder.DropTable(
                name: "VideoActors");

            migrationBuilder.DropTable(
                name: "VideoDirectors");

            migrationBuilder.DropTable(
                name: "VideoGenres");

            migrationBuilder.DropTable(
                name: "VideoPublishers");

            migrationBuilder.DropTable(
                name: "VideoStudios");

            migrationBuilder.DropTable(
                name: "VideoTags");

            migrationBuilder.DropTable(
                name: "Casts");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Studios");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Librarys");

            migrationBuilder.DropTable(
                name: "Serieses");
        }
    }
}
