namespace OrgaTournoi.Models
{
    public class Fabricant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Type { get; set; }
        public string Siret { get; set; }
        public string Directeur { get; set; }
        public string Lien { get; set; }

        // Reference n vers n Jeu
        public ICollection<Jeu> Jeux { get; set; }

        public Fabricant()
        {
            this.Jeux = new HashSet<Jeu>();
        }

    }
}
