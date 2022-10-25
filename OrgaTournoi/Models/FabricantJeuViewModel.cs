namespace OrgaTournoi.Models
{
    public class FabricantJeuViewModel
    {
        public Fabricant Fabricant { get; set; }
        public List<Jeu> Jeux { get; set; }


        public FabricantJeuViewModel(Fabricant fabricant, List<Jeu> jeux)
        {
            Fabricant = fabricant;
            Jeux = jeux;
        }
    }
}
