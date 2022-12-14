// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrgaTournoi.Data;

#nullable disable

namespace OrgaTournoi.Migrations
{
    [DbContext(typeof(OrgaTournoiContext))]
    partial class OrgaTournoiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EquipeMatch", b =>
                {
                    b.Property<int>("EquipesId")
                        .HasColumnType("int");

                    b.Property<int>("MatchsId")
                        .HasColumnType("int");

                    b.HasKey("EquipesId", "MatchsId");

                    b.HasIndex("MatchsId");

                    b.ToTable("EquipeMatch");
                });

            modelBuilder.Entity("FabricantJeu", b =>
                {
                    b.Property<int>("FabricantsId")
                        .HasColumnType("int");

                    b.Property<int>("JeuxId")
                        .HasColumnType("int");

                    b.HasKey("FabricantsId", "JeuxId");

                    b.HasIndex("JeuxId");

                    b.ToTable("FabricantJeu");
                });

            modelBuilder.Entity("JeuPersonnage", b =>
                {
                    b.Property<int>("JeuxId")
                        .HasColumnType("int");

                    b.Property<int>("PersonnagesId")
                        .HasColumnType("int");

                    b.HasKey("JeuxId", "PersonnagesId");

                    b.HasIndex("PersonnagesId");

                    b.ToTable("JeuPersonnage");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Classement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Classement");
                });

            modelBuilder.Entity("OrgaTournoi.Models.ClassementEquipe", b =>
                {
                    b.Property<int>("ClassementId")
                        .HasColumnType("int");

                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<string>("Cashprize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("ClassementId", "EquipeId");

                    b.HasIndex("EquipeId");

                    b.ToTable("ClassementEquipe");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Equipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CashpriceTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaysId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Equipe");
                });

            modelBuilder.Entity("OrgaTournoi.Models.EquipeJoueur", b =>
                {
                    b.Property<int>("EquipeId")
                        .HasColumnType("int");

                    b.Property<int>("JoueurId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateArrive")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("datetime2");

                    b.HasKey("EquipeId", "JoueurId");

                    b.HasIndex("JoueurId");

                    b.ToTable("EquipeJoueur");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Evenement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cashprize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JeuId")
                        .HasColumnType("int");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaysId")
                        .HasColumnType("int");

                    b.Property<int>("classementId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JeuId");

                    b.HasIndex("PaysId");

                    b.HasIndex("classementId");

                    b.ToTable("Evenement");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Fabricant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Directeur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Siret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricant");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Jeu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateSortie")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jeu");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Joueur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CashprizeTotal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaysId")
                        .HasColumnType("int");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pseudo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Joueur");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int>("EvenementId")
                        .HasColumnType("int");

                    b.Property<string>("LienStreaming")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EvenementId");

                    b.ToTable("Match");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Personnage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personnage");
                });

            modelBuilder.Entity("EquipeMatch", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Equipe", null)
                        .WithMany()
                        .HasForeignKey("EquipesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Match", null)
                        .WithMany()
                        .HasForeignKey("MatchsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FabricantJeu", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Fabricant", null)
                        .WithMany()
                        .HasForeignKey("FabricantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Jeu", null)
                        .WithMany()
                        .HasForeignKey("JeuxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JeuPersonnage", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Jeu", null)
                        .WithMany()
                        .HasForeignKey("JeuxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Personnage", null)
                        .WithMany()
                        .HasForeignKey("PersonnagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrgaTournoi.Models.ClassementEquipe", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Classement", "Classement")
                        .WithMany("ClassementsEquipes")
                        .HasForeignKey("ClassementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Equipe", "Equipe")
                        .WithMany("ClassementsEquipes")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classement");

                    b.Navigation("Equipe");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Equipe", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Pays", "Pays")
                        .WithMany("Equipes")
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("OrgaTournoi.Models.EquipeJoueur", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Equipe", "Equipe")
                        .WithMany("EquipesJoueurs")
                        .HasForeignKey("EquipeId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Joueur", "Joueur")
                        .WithMany("EquipesJoueurs")
                        .HasForeignKey("JoueurId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Equipe");

                    b.Navigation("Joueur");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Evenement", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Jeu", "jeu")
                        .WithMany("Evenements")
                        .HasForeignKey("JeuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Pays", "Pays")
                        .WithMany("Evenements")
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgaTournoi.Models.Classement", "classement")
                        .WithMany()
                        .HasForeignKey("classementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");

                    b.Navigation("classement");

                    b.Navigation("jeu");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Joueur", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Pays", "Pays")
                        .WithMany("Joueurs")
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Match", b =>
                {
                    b.HasOne("OrgaTournoi.Models.Evenement", "Evenement")
                        .WithMany("Matchs")
                        .HasForeignKey("EvenementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evenement");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Classement", b =>
                {
                    b.Navigation("ClassementsEquipes");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Equipe", b =>
                {
                    b.Navigation("ClassementsEquipes");

                    b.Navigation("EquipesJoueurs");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Evenement", b =>
                {
                    b.Navigation("Matchs");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Jeu", b =>
                {
                    b.Navigation("Evenements");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Joueur", b =>
                {
                    b.Navigation("EquipesJoueurs");
                });

            modelBuilder.Entity("OrgaTournoi.Models.Pays", b =>
                {
                    b.Navigation("Equipes");

                    b.Navigation("Evenements");

                    b.Navigation("Joueurs");
                });
#pragma warning restore 612, 618
        }
    }
}
