namespace OrgaTournoi.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        
        // Reference au jeu
        public int JeuId { get; set; }
        public Jeu jeu { get; set; }

        public Classement classement { get; set; }
        public string Nom { get; set; }
        public string Image { get; set; }
        public string Lieu { get; set; }

        // Reference au pays
        public int PaysId { get; set; }
        public Pays Pays { get; set; }
        public DateTime DateDebut {get; set; }
        public DateTime DateFin {get; set; }
        public string Cashprize { get; set; }


        // Reference 1 vers n Match
        public ICollection<Match> Matchs { get; set; }


        public Evenement()
        {
            this.Matchs = new HashSet<Match>();
        }
    }
}
