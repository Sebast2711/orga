using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrgaTournoi.Models;


namespace OrgaTournoi.Data
{
    public class OrgaTournoiContext : DbContext
    {
        public OrgaTournoiContext (DbContextOptions<OrgaTournoiContext> options)
            : base(options)
        {
        }

        public DbSet<OrgaTournoi.Models.Classement> Classement { get; set; } = default!;

        public DbSet<OrgaTournoi.Models.Equipe> Equipe { get; set; }

        public DbSet<OrgaTournoi.Models.Evenement> Evenement { get; set; }

        public DbSet<OrgaTournoi.Models.Fabricant> Fabricant { get; set; }

        public DbSet<OrgaTournoi.Models.Jeu> Jeu { get; set; }

        public DbSet<OrgaTournoi.Models.Joueur> Joueur { get; set; }

        public DbSet<OrgaTournoi.Models.Match> Match { get; set; }

        public DbSet<OrgaTournoi.Models.Pays> Pays { get; set; }

        public DbSet<OrgaTournoi.Models.Personnage> Personnage { get; set; }

        //Mise en place des associations ClassementEquipe et EquipeJoueur
        //Pour avoir des attributs spécifiques à ces associations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Association ClassementEquipe
            
            modelBuilder.Entity<ClassementEquipe>()
                .HasKey(t => new { t.ClassementId, t.EquipeId });

            modelBuilder.Entity<ClassementEquipe>()
                .HasOne(pt => pt.Classement)
                .WithMany(p => p.ClassementsEquipes)
                .HasForeignKey(pt => pt.ClassementId);

            modelBuilder.Entity<ClassementEquipe>()
                .HasOne(pt => pt.Equipe)
                .WithMany(t => t.ClassementsEquipes)
                .HasForeignKey(pt => pt.EquipeId);

            // Association EquipeJoueur

            modelBuilder.Entity<EquipeJoueur>()
                .HasKey(t => new { t.EquipeId, t.JoueurId });
                

            modelBuilder.Entity<EquipeJoueur>()
                .HasOne(pt => pt.Equipe)
                .WithMany(t => t.EquipesJoueurs)
                .HasForeignKey(pt => pt.EquipeId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<EquipeJoueur>()
                .HasOne(pt => pt.Joueur)
                .WithMany(p => p.EquipesJoueurs)
                .HasForeignKey(pt => pt.JoueurId)
                .OnDelete(DeleteBehavior.ClientCascade);


        }

        //Mise en place des associations ClassementEquipe et EquipeJoueur
        //Pour avoir des attributs spécifiques à ces associations
        public DbSet<OrgaTournoi.Models.ClassementEquipe> ClassementEquipe { get; set; }

    }
}
