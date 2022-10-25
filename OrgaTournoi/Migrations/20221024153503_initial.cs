using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrgaTournoi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Siret = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Directeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lien = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personnage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricantJeu",
                columns: table => new
                {
                    FabricantsId = table.Column<int>(type: "int", nullable: false),
                    JeuxId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricantJeu", x => new { x.FabricantsId, x.JeuxId });
                    table.ForeignKey(
                        name: "FK_FabricantJeu_Fabricant_FabricantsId",
                        column: x => x.FabricantsId,
                        principalTable: "Fabricant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FabricantJeu_Jeu_JeuxId",
                        column: x => x.JeuxId,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashpriceTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipe_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JeuId = table.Column<int>(type: "int", nullable: false),
                    classementId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lieu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cashprize = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evenement_Classement_classementId",
                        column: x => x.classementId,
                        principalTable: "Classement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evenement_Jeu_JeuId",
                        column: x => x.JeuId,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evenement_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Joueur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pseudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaysId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CashprizeTotal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joueur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joueur_Pays_PaysId",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "JeuPersonnage",
                columns: table => new
                {
                    JeuxId = table.Column<int>(type: "int", nullable: false),
                    PersonnagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JeuPersonnage", x => new { x.JeuxId, x.PersonnagesId });
                    table.ForeignKey(
                        name: "FK_JeuPersonnage_Jeu_JeuxId",
                        column: x => x.JeuxId,
                        principalTable: "Jeu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JeuPersonnage_Personnage_PersonnagesId",
                        column: x => x.PersonnagesId,
                        principalTable: "Personnage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Match",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EvenementId = table.Column<int>(type: "int", nullable: false),
                    LienStreaming = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Match", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Match_Evenement_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "EquipeMatch",
                columns: table => new
                {
                    EquipesId = table.Column<int>(type: "int", nullable: false),
                    MatchsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeMatch", x => new { x.EquipesId, x.MatchsId });
                    table.ForeignKey(
                        name: "FK_EquipeMatch_Equipe_EquipesId",
                        column: x => x.EquipesId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EquipeMatch_Match_MatchsId",
                        column: x => x.MatchsId,
                        principalTable: "Match",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassementEquipe_EquipeId",
                table: "ClassementEquipe",
                column: "EquipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_PaysId",
                table: "Equipe",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeJoueur_JoueurId",
                table: "EquipeJoueur",
                column: "JoueurId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeMatch_MatchsId",
                table: "EquipeMatch",
                column: "MatchsId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_classementId",
                table: "Evenement",
                column: "classementId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_JeuId",
                table: "Evenement",
                column: "JeuId");

            migrationBuilder.CreateIndex(
                name: "IX_Evenement_PaysId",
                table: "Evenement",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricantJeu_JeuxId",
                table: "FabricantJeu",
                column: "JeuxId");

            migrationBuilder.CreateIndex(
                name: "IX_JeuPersonnage_PersonnagesId",
                table: "JeuPersonnage",
                column: "PersonnagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Joueur_PaysId",
                table: "Joueur",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "IX_Match_EvenementId",
                table: "Match",
                column: "EvenementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassementEquipe");

            migrationBuilder.DropTable(
                name: "EquipeJoueur");

            migrationBuilder.DropTable(
                name: "EquipeMatch");

            migrationBuilder.DropTable(
                name: "FabricantJeu");

            migrationBuilder.DropTable(
                name: "JeuPersonnage");

            migrationBuilder.DropTable(
                name: "Joueur");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Match");

            migrationBuilder.DropTable(
                name: "Fabricant");

            migrationBuilder.DropTable(
                name: "Personnage");

            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "Classement");

            migrationBuilder.DropTable(
                name: "Jeu");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
