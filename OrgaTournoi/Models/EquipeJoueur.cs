namespace OrgaTournoi.Models
{
    public class EquipeJoueur
    {
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }
        public int JoueurId { get; set; }
        public Joueur Joueur { get; set; }
        public DateTime DateArrive { get; set; }
        public DateTime DateDepart { get; set; }
    }
}
