using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrgaTournoi.Migrations
{
    public partial class RemoveAssociations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassementEquipe");

            migrationBuilder.DropTable(
                name: "EquipeJoueur");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassementEquipe",
                columns: table => new
                {
                    ClassementsId = table.Column<int>(type: "int", nullable: false),
                    EquipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassementEquipe", x => new { x.ClassementsId, x.EquipesId });
                    table.ForeignKey(
                        name: "FK_ClassementEquipe_Classement_ClassementsId",
                        column: x => x.ClassementsId,
                        principalTable: "Classement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassementEquipe_Equipe_EquipesId",
                        column: x => x.EquipesId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipeJoueur",
                columns: table => new
                {
                    EquipesId = table.Column<int>(type: "int", nullable: false),
                    JoueursId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeJoueur", x => new { x.EquipesId, x.JoueursId });
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Equipe_EquipesId",
                        column: x => x.EquipesId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Joueur_JoueursId",
                        column: x => x.JoueursId,
                        principalTable: "Joueur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassementEquipe_EquipesId",
                table: "ClassementEquipe",
                column: "EquipesId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_JoueursId",
                table: "EquipeJoueur",
                column: "JoueursId");
        }
    }
}
