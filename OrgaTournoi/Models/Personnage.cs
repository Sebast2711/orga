namespace OrgaTournoi.Models
{
    public class Personnage
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string? Description { get; set; }
        public string Image { get; set; }

        // Reference n vers n Jeu
        public ICollection<Jeu> Jeux { get; set; }

        public Personnage()
        {
            this.Jeux = new HashSet<Jeu>();
        }
    }
}
