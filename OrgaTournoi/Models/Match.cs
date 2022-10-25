namespace OrgaTournoi.Models
{
    public class Match
    {
        public int Id { get; set; }

        // Reference a l'evenement
        public int EvenementId { get; set; }
        public Evenement Evenement { get; set; }


        public string LienStreaming { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public string Score { get; set; }

        // Reference n vers n equipe
        public ICollection<Equipe> Equipes { get; set; }



        public Match()
        {
            this.Equipes = new HashSet<Equipe>();
        }

    }
}
