namespace OrgaTournoi.Models
{
    public class JeuTournoiJoueurViewModel
    {
        public Jeu Jeu { get; set; }
        public List<Evenement> Evenements { get; set; }
        public List<Joueur> Joueurs { get; set; }

        public JeuTournoiJoueurViewModel(Jeu jeu, List<Evenement> evenements, List<Joueur> joueurs)
        {
            Jeu = jeu;
            Evenements = evenements;
            Joueurs = joueurs;
        }
    }
}
