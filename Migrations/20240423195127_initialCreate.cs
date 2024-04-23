using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OregonTrail.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caravan",
                columns: table => new
                {
                    CaravanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caravan", x => x.CaravanId);
                });

            migrationBuilder.CreateTable(
                name: "Wagon",
                columns: table => new
                {
                    WagonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumWheels = table.Column<int>(type: "int", nullable: false),
                    Covered = table.Column<bool>(type: "bit", nullable: false),
                    CaravanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagon", x => x.WagonId);
                    table.ForeignKey(
                        name: "FK_Wagon_Caravan_CaravanId",
                        column: x => x.CaravanId,
                        principalTable: "Caravan",
                        principalColumn: "CaravanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passanger",
                columns: table => new
                {
                    PassangerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WagonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passanger", x => x.PassangerId);
                    table.ForeignKey(
                        name: "FK_Passanger_Wagon_WagonId",
                        column: x => x.WagonId,
                        principalTable: "Wagon",
                        principalColumn: "WagonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passanger_WagonId",
                table: "Passanger",
                column: "WagonId");

            migrationBuilder.CreateIndex(
                name: "IX_Wagon_CaravanId",
                table: "Wagon",
                column: "CaravanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passanger");

            migrationBuilder.DropTable(
                name: "Wagon");

            migrationBuilder.DropTable(
                name: "Caravan");
        }
    }
}
