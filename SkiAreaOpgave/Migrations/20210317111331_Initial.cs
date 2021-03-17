using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkiAreaOpgave.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestID);
                });

            migrationBuilder.CreateTable(
                name: "Slope",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlopeCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Primed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slope", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Skilift",
                columns: table => new
                {
                    SkiliftId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    to = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    from = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    speed = table.Column<float>(type: "real", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    areaName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skilift", x => x.SkiliftId);
                    table.ForeignKey(
                        name: "FK_Skilift_Area_areaName",
                        column: x => x.areaName,
                        principalTable: "Area",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skipass",
                columns: table => new
                {
                    SkipassId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skipass", x => x.SkipassId);
                    table.ForeignKey(
                        name: "FK_Skipass_Guest_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guest",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaSlope",
                columns: table => new
                {
                    AreasName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SlopesName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaSlope", x => new { x.AreasName, x.SlopesName });
                    table.ForeignKey(
                        name: "FK_AreaSlope_Area_AreasName",
                        column: x => x.AreasName,
                        principalTable: "Area",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaSlope_Slope_SlopesName",
                        column: x => x.SlopesName,
                        principalTable: "Slope",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaSkipass",
                columns: table => new
                {
                    AreaListName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SkipassesSkipassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaSkipass", x => new { x.AreaListName, x.SkipassesSkipassId });
                    table.ForeignKey(
                        name: "FK_AreaSkipass_Area_AreaListName",
                        column: x => x.AreaListName,
                        principalTable: "Area",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaSkipass_Skipass_SkipassesSkipassId",
                        column: x => x.SkipassesSkipassId,
                        principalTable: "Skipass",
                        principalColumn: "SkipassId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaSkipass_SkipassesSkipassId",
                table: "AreaSkipass",
                column: "SkipassesSkipassId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaSlope_SlopesName",
                table: "AreaSlope",
                column: "SlopesName");

            migrationBuilder.CreateIndex(
                name: "IX_Skilift_areaName",
                table: "Skilift",
                column: "areaName");

            migrationBuilder.CreateIndex(
                name: "IX_Skipass_GuestID",
                table: "Skipass",
                column: "GuestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaSkipass");

            migrationBuilder.DropTable(
                name: "AreaSlope");

            migrationBuilder.DropTable(
                name: "Skilift");

            migrationBuilder.DropTable(
                name: "Skipass");

            migrationBuilder.DropTable(
                name: "Slope");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Guest");
        }
    }
}
