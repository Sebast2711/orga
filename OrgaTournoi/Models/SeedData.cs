using Microsoft.EntityFrameworkCore;
using OrgaTournoi.Data;

namespace OrgaTournoi.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {



            using (var context = new OrgaTournoiContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<OrgaTournoiContext>>()))
            {


                // Creation des Joueurs
                if (!context.Joueur.Any())
                {
                    context.Joueur.AddRange(
                   new Joueur
                   {
                       Prenom = "William",
                       Pseudo = "Glutonny",
                       Nom = "Belaid",
                       Age = 27,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Nassim ",
                       Pseudo = "Leon",
                       Nom = "Laib",
                       Age = 34,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Enki ",
                       Pseudo = "Enki ",
                       Nom = "Dufoyer",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Paris",
                       Pseudo = "Light",
                       Nom = "Ramirez Garcia",
                       Age = 23,
                       PaysId = 5,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Tyler  ",
                       Pseudo = "Marss ",
                       Nom = "Martins",
                       Age = 23,
                       PaysId = 5,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Samuel Robert",
                       Pseudo = "Dabuz ",
                       Nom = "Buzby",
                       Age = 29,
                       PaysId = 5,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "Kolawole",
                       Pseudo = "Kola",
                       Nom = "Aideyan",
                       Age = 25,
                       PaysId = 5,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "Fallen",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "fer",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "coldzera",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "boltz",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "Stewie2k",
                       Nom = "",
                       Age = 25,
                       PaysId = 5,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "krimz",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "mezii",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "nicoodoz",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "roeJ",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   },
                   new Joueur
                   {
                       Prenom = "",
                       Pseudo = "Fashr",
                       Nom = "",
                       Age = 25,
                       PaysId = 2,
                       Description = "",
                       CashprizeTotal = "0"
                   }
               );
                }

                // Creation des Jeux
                if (!context.Jeu.Any())
                {
                    context.Jeu.AddRange(
                    new Jeu
                    {
                        Nom = "League Of Legends",
                        Image = "",
                        Description = "",
                        DateSortie = new DateTime(2009, 10, 27, 0, 0, 0)
                    },
                    new Jeu
                    {
                        Nom = "Counter Strike : Global Offensive",
                        Image = "",
                        Description = "",
                        DateSortie = new DateTime(2012, 8, 21, 0, 0, 0)
                    }
                );
                }

                // Creation des Pays
                if (!context.Pays.Any())
                {
                    context.Pays.AddRange(
                   new Pays
                   {
                       Nom = "France",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Angleterre",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Espagne",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Chine",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Etats-Unis",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Japon",
                       Image = ""
                   },
                   new Pays
                   {
                       Nom = "Coree du Sud",
                       Image = ""
                   }
               );
                }

                // Creation des Evenements
                if (!context.Evenement.Any())
                {
                    context.Evenement.AddRange(
                        new Evenement
                        {
                            JeuId = 1,
                            Nom = "Dreamhack Atlanta 2022",
                            PaysId = 5,
                            classement = new Classement(),
                            Image = "",
                            Lieu = "Atlanta",
                            DateDebut = new DateTime(2022, 11, 18, 0, 0, 0),
                            DateFin = new DateTime(2022, 11, 20, 0, 0, 0),
                            Cashprize = "2500"
                        },
                        new Evenement
                        {
                            JeuId = 1,
                            Nom = "Smash World Tour 2022",
                            PaysId = 5,
                            classement = new Classement(),
                            Image = "",
                            Lieu = "World",
                            DateDebut = new DateTime(2022, 3, 12, 0, 0, 0),
                            DateFin = new DateTime(2022, 12, 11, 0, 0, 0),
                            Cashprize = "2500"
                        },
                        new Evenement
                        {
                            JeuId = 3,
                            Nom = "BLAST.tv Paris Major 2023",
                            PaysId = 1,
                            classement = new Classement(),
                            Image = "",
                            Lieu = "Paris",
                            DateDebut = new DateTime(2023, 5, 8, 0, 0, 0),
                            DateFin = new DateTime(2023, 5, 21, 0, 0, 0),
                            Cashprize = "1250000"
                        },
                        new Evenement
                        {
                            JeuId = 3,
                            Nom = "CCT North Europe Series #1",
                            PaysId = 1,
                            classement = new Classement(),
                            Image = "",
                            Lieu = "Paris",
                            DateDebut = new DateTime(2022, 10, 11, 0, 0, 0),
                            DateFin = new DateTime(2022, 10, 24, 0, 0, 0),
                            Cashprize = "50000"
                        }
                    );
                }

                // Creation des Equipes
                if (!context.Equipe.Any())
                {
                    context.Equipe.AddRange(
                        new Equipe
                        {
                            Nom = "Glutonny",
                            Image = "",
                            Description = "Solo Glutonny",
                            CashpriceTotal = "",
                            PaysId = 1
                        },
                        new Equipe
                        {
                            Nom = "SKT",
                            Image = "",
                            Description = "",
                            CashpriceTotal = "",
                            PaysId = 5
                        },
                        new Equipe
                        {
                            Nom = "Fnatic",
                            Image = "",
                            Description = "",
                            CashpriceTotal = "",
                            PaysId = 5
                        }
                    );
                }

                // Creation des Personnages
                if (!context.Personnage.Any())
                {
                    context.Personnage.AddRange(
                        new Personnage
                          {
                              Nom = "Senna",
                              Description = "",
                              Image = ""
                          }, new Personnage
                          {
                              Nom = "Ezreal",
                              Description = "",
                              Image = ""
                          }, new Personnage
                          {
                              Nom = "Lucian",
                              Description = "",
                              Image = ""
                          }, new Personnage
                          {
                              Nom = "Nami",
                              Description = "",
                              Image = ""
                          }, new Personnage
                          {
                              Nom = "Varus",
                              Description = "",
                              Image = ""
                          }, new Personnage
                          {
                              Nom = "Ashe",
                              Description = "",
                              Image = ""
                          }
                    );
                }

                // Creation des Fabricants
                if (!context.Fabricant.Any())
                {
                    context.Fabricant.AddRange(
                        new Fabricant
                        {
                            Nom = "Bandai Namco Studios",
                            Type = "dev",
                            Siret = "",
                            Directeur = "",
                            Lien = "https://fr.bandainamcoent.eu/"
                        },
                        new Fabricant
                        {
                            Nom = "Valve",
                            Type = "edit",
                            Siret = "",
                            Directeur = "",
                            Lien = "https://www.valvesoftware.com/fr/"
                        },
                        new Fabricant
                        {
                            Nom = "Riot Games",
                            Type = "dev",
                            Siret = "",
                            Directeur = "",
                            Lien = "https://www.riotgames.com/fr"
                        }
                    );

                }

                /* var fab1 = new Fabricant
                 {
                     Nom = "Psyonix",
                     Type = "edit",
                     Siret = "",
                     Directeur = "",
                     Lien = "https://www.psyonix.com/fr/"
                 };
                 var jeu1 = new Jeu
                 {
                     Nom = "Rocket League",
                     Image = "",
                     Description = "",
                     DateSortie = new DateTime(2018, 12, 7, 0, 0, 0)
                 };*/


                /*fab1.Jeux.Add(jeu1);
                jeu1.Fabricants.Add(fab1);
                context.Jeu.Add(jeu1);
                context.Fabricant.Add(fab1);*/

               /* var SSBU = new Jeu
                {
                    Nom = "Super Smash Bros Ultimate",
                    Image = "",
                    Description = "",
                    DateSortie = new DateTime(2018, 12, 7, 0, 0, 0)
                };

                var Pikachu = new Personnage
                {
                    Nom = "Mario",
                    Description = "",
                    Image = ""
                };
                var Luigi = new Personnage
                {
                    Nom = "Luigi",
                    Description = "",
                    Image = ""
                };
                var Wario = new Personnage
                {
                    Nom = "Wario",
                    Description = "",
                    Image = ""
                };
                var Sonic = new Personnage
                {
                    Nom = "Sonic",
                    Description = "",
                    Image = ""
                };
                var Peach = new Personnage
                {
                    Nom = "Peach",
                    Description = "",
                    Image = ""
                };
                var Kirby = new Personnage
                {
                    Nom = "kirby",
                    Description = "",
                    Image = ""
                };
                SSBU.Personnages.Add(Pikachu);
                SSBU.Personnages.Add(Luigi);
                SSBU.Personnages.Add(Wario);
                SSBU.Personnages.Add(Sonic);
                SSBU.Personnages.Add(Peach);
                SSBU.Personnages.Add(Kirby);

                Pikachu.Jeux.Add(SSBU);
                Luigi.Jeux.Add(SSBU);
                Wario.Jeux.Add(SSBU);
                Sonic.Jeux.Add(SSBU);
                Peach.Jeux.Add(SSBU);
                Kirby.Jeux.Add(SSBU);

                context.Jeu.Add(SSBU);
                context.Personnage.AddRange(Pikachu, Luigi, Wario, Sonic, Peach, Kirby);
*/

                context.SaveChanges();
            }
        }



    }
}
