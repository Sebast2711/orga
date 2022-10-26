using Microsoft.EntityFrameworkCore;
using OrgaTournoi.Data;

namespace OrgaTournoi.Models
{
    public class SeedData2
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrgaTournoiContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<OrgaTournoiContext>>()))
            {
                /*
                                // Fixtures Pays
                                var France = new Pays
                                {
                                    Nom = "France",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png"
                                };
                                var Angleterre = new Pays
                                {
                                    Nom = "Angleterre",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/83/Flag_of_the_United_Kingdom_%283-5%29.svg/langfr-225px-Flag_of_the_United_Kingdom_%283-5%29.svg.png"
                                };
                                var Chine = new Pays
                                {
                                    Nom = "Chine",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fa/Flag_of_the_People%27s_Republic_of_China.svg/1280px-Flag_of_the_People%27s_Republic_of_China.svg.png"
                                };
                                var EtatsUnis = new Pays
                                {
                                    Nom = "Etats-Unis",
                                    Image = "https://www.larousse.fr/encyclopedie/data/images/1009488-Drapeau_des_%C3%89tats-Unis.jpg"
                                };
                                var Japon = new Pays
                                {
                                    Nom = "Japon",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9e/Flag_of_Japan.svg/langfr-225px-Flag_of_Japan.svg.png"
                                };
                                var CoreeDuSud = new Pays
                                {
                                    Nom = "Coree du Sud",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/09/Flag_of_South_Korea.svg/langfr-225px-Flag_of_South_Korea.svg.png"
                                };
                                var Bresil = new Pays
                                {
                                    Nom = "Bresil",
                                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/05/Flag_of_Brazil.svg/langfr-225px-Flag_of_Brazil.svg.png"
                                };

                                context.Pays.AddRange(France, Angleterre, Chine, EtatsUnis, Japon, CoreeDuSud, Bresil);
                                context.SaveChanges();
                */
                // Fixtures Jeux
                /*               var SSBU = new Jeu
                               {
                                   Nom = "Super Smash Bros Ultimate",
                                   Image = "https://www.smashbros.com/data/bs/fr_FR/en_GB/img/1_US.jpg",
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but ",
                                   DateSortie = new DateTime(2018, 12, 7, 0, 0, 0)
                               };
                               var CSGO = new Jeu
                               {
                                   Nom = "Counter Strike : Global Offensive",
                                   Image = "https://cdn.akamai.steamstatic.com/steam/apps/730/capsule_616x353.jpg?t=1641233427",
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but ",
                                   DateSortie = new DateTime(2012, 8, 21, 0, 0, 0)
                               };
                               var LOL = new Jeu
                               {
                                   Nom = "League Of Legends",
                                   Image = "https://www.pedagojeux.fr/wp-content/uploads/2019/11/1280x720_LoL.jpg",
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but ",
                                   DateSortie = new DateTime(2009, 10, 27, 0, 0, 0)
                               };


                               context.Jeu.AddRange(SSBU, CSGO, LOL);



                               // Fixtures Fabricant
                               var Bandai = new Fabricant
                               {
                                   Nom = "Bandai Namco Studios",
                                   Type = "dev",
                                   Siret = "",
                                   Directeur = "",
                                   Lien = "https://fr.bandainamcoent.eu/"
                               };
                               var Valve = new Fabricant
                               {
                                   Nom = "Valve",
                                   Type = "edit",
                                   Siret = "",
                                   Directeur = "",
                                   Lien = "https://www.valvesoftware.com/fr/"
                               };
                               var Riot = new Fabricant
                               {
                                   Nom = "Riot Games",
                                   Type = "dev",
                                   Siret = "",
                                   Directeur = "",
                                   Lien = "https://www.riotgames.com/fr"
                               };

                               SSBU.Fabricants.Add(Bandai);
                               CSGO.Fabricants.Add(Valve);
                               LOL.Fabricants.Add(Riot);
                               Bandai.Jeux.Add(SSBU);
                               Valve.Jeux.Add(CSGO);
                               Riot.Jeux.Add(LOL);

                               context.Fabricant.AddRange(Bandai, Valve, Riot);


                               // Fixtures Personnage
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

                               context.Personnage.AddRange(Pikachu, Luigi, Wario, Sonic, Peach, Kirby);
                               context.SaveChanges();

                               var Glutonny = new Joueur
                               {
                                   Prenom = "William",
                                   Pseudo = "Glutonny",
                                   Nom = "Belaid",
                                   Age = 27,
                                   PaysId = 1,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Leon = new Joueur
                               {
                                   Prenom = "Nassim ",
                                   Pseudo = "Leon",
                                   Nom = "Laib",
                                   Age = 34,
                                   PaysId = 1,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Enki = new Joueur
                               {
                                   Prenom = "Enki ",
                                   Pseudo = "Enki ",
                                   Nom = "Dufoyer",
                                   Age = 25,
                                   PaysId = 1,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Light = new Joueur
                               {
                                   Prenom = "Paris",
                                   Pseudo = "Light",
                                   Nom = "Ramirez Garcia",
                                   Age = 23,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Marss = new Joueur
                               {
                                   Prenom = "Tyler  ",
                                   Pseudo = "Marss ",
                                   Nom = "Martins",
                                   Age = 23,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Dabuz = new Joueur
                               {
                                   Prenom = "Samuel Robert",
                                   Pseudo = "Dabuz ",
                                   Nom = "Buzby",
                                   Age = 29,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Kola = new Joueur
                               {
                                   Prenom = "Kolawole",
                                   Pseudo = "Kola",
                                   Nom = "Aideyan",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Fallen = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "Fallen",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 7,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Fer = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "fer",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 7,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Coldzera = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "coldzera",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 7,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Boltz = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "boltz",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 7,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Stewie = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "Stewie2k",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Krimz = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "krimz",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Mezii = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "mezii",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Nico = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "nicoodoz",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Roej = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "roeJ",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };
                               var Fashr = new Joueur
                               {
                                   Prenom = "",
                                   Pseudo = "Fashr",
                                   Nom = "",
                                   Age = 25,
                                   PaysId = 4,
                                   Description = "",
                                   CashprizeTotal = "0"
                               };

                               context.Joueur.AddRange(Glutonny, Leon, Enki, Light, Marss, Dabuz, Kola, Fallen, Fer, Coldzera, Boltz, Stewie, Krimz, Mezii, Nico, Roej, Fashr);


                               var SKGaming = new Equipe
                               {
                                   Nom = "SKGaming",
                                   PaysId = 7,
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but ",
                                   Image = "https://upload.wikimedia.org/wikipedia/fr/c/cd/SK_2020_black.png",
                                   CashpriceTotal = "0"
                               };
                               var Fnatic = new Equipe
                               {
                                   Nom = "Fnatic",
                                   PaysId = 4,
                                   Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but ",
                                   Image = "https://upload.wikimedia.org/wikipedia/fr/thumb/f/f4/Fnatic-Logo-2020.svg/1200px-Fnatic-Logo-2020.svg.png",
                                   CashpriceTotal = "0"
                               };


                               context.AddRange(SKGaming, Fnatic);

                               context.SaveChanges();*/

                // Evenement
                if (!context.Evenement.Any())
                {
                    var DH = new Evenement
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
                    };
                    var SWT = new Evenement
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
                    };
                    var blast = new Evenement
                    {
                        JeuId = 2,
                        Nom = "BLAST.tv Paris Major 2023",
                        PaysId = 1,
                        classement = new Classement(),
                        Image = "",
                        Lieu = "Paris",
                        DateDebut = new DateTime(2023, 5, 8, 0, 0, 0),
                        DateFin = new DateTime(2023, 5, 21, 0, 0, 0),
                        Cashprize = "1250000"
                    };
                    var cct = new Evenement
                    {
                        JeuId = 2,
                        Nom = "CCT North Europe Series #1",
                        PaysId = 1,
                        classement = new Classement(),
                        Image = "",
                        Lieu = "Paris",
                        DateDebut = new DateTime(2022, 10, 11, 0, 0, 0),
                        DateFin = new DateTime(2022, 10, 24, 0, 0, 0),
                        Cashprize = "50000"
                    };
                    context.AddRange(DH, SWT, blast, cct);
                }




                context.SaveChanges();


            }
        }
    }
}
