using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrgaTournoi.Migrations
{
    public partial class AddAssociationsCE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassementEquipe",
                columns: table => new
                {
                    ClassementId = table.Column<int>(type: "int", nullable: false),
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    Cashprize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassementEquipe", x => new { x.ClassementId, x.EquipeId });
                    table.ForeignKey(
                        name: "FK_ClassementEquipe_Classement_ClassementId",
                        column: x => x.ClassementId,
                        principalTable: "Classement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassementEquipe_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassementEquipe_EquipeId",
                table: "ClassementEquipe",
                column: "EquipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassementEquipe");
        }
    }
}
