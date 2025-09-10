using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace passeio_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TourStops",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourStops", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tours_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "TourItem",
                columns: table => new
                {
                    TourStopsID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToursID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourItem", x => new { x.TourStopsID, x.ToursID });
                    table.ForeignKey(
                        name: "FK_TourItem_TourStops_TourStopsID",
                        column: x => x.TourStopsID,
                        principalTable: "TourStops",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourItem_Tours_ToursID",
                        column: x => x.ToursID,
                        principalTable: "Tours",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourItem_ToursID",
                table: "TourItem",
                column: "ToursID");

            migrationBuilder.CreateIndex(
                name: "IX_Tours_ProfileId",
                table: "Tours",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourItem");

            migrationBuilder.DropTable(
                name: "TourStops");

            migrationBuilder.DropTable(
                name: "Tours");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
