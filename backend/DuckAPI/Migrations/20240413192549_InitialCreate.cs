using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DuckAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ducklores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ducklores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Duckusers",
                columns: table => new
                {
                    DuckUserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duckusername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuckPW = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duckusers", x => x.DuckUserID);
                });

            migrationBuilder.CreateTable(
                name: "Ducks",
                columns: table => new
                {
                    DuckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuckloreID = table.Column<int>(type: "int", nullable: false),
                    DuckName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuckColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuckGender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ducks", x => x.DuckID);
                    table.ForeignKey(
                        name: "FK_Ducks_Ducklores_DuckloreID",
                        column: x => x.DuckloreID,
                        principalTable: "Ducklores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ducks_DuckloreID",
                table: "Ducks",
                column: "DuckloreID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ducks");

            migrationBuilder.DropTable(
                name: "Duckusers");

            migrationBuilder.DropTable(
                name: "Ducklores");
        }
    }
}
