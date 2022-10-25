namespace OrgaTournoi.Models
{
    public class PersonnageJeuViewModel
    {
        public List <Personnage> Personnages { get; set; }
        public Jeu Jeu { get; set; }


        public PersonnageJeuViewModel (Jeu jeu, List<Personnage> personnages)
        {
            Jeu = jeu;
            Personnages = personnages;
        }
    }
}
