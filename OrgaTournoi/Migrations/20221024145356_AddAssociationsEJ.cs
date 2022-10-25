using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrgaTournoi.Migrations
{
    public partial class AddAssociationsEJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipeJoueur",
                columns: table => new
                {
                    EquipeId = table.Column<int>(type: "int", nullable: false),
                    JoueurId = table.Column<int>(type: "int", nullable: false),
                    DateArrive = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDepart = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeJoueur", x => new { x.EquipeId, x.JoueurId });
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Equipe_EquipeId",
                        column: x => x.EquipeId,
                        principalTable: "Equipe",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipeJoueur_Joueur_JoueurId",
                        column: x => x.JoueurId,
                        principalTable: "Joueur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_JoueurId",
                table: "EquipeJoueur",
                column: "JoueurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeJoueur");
        }
    }
}
