using System.ComponentModel.DataAnnotations;

namespace OrgaTournoi.Models
{
    public class Jeu
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        [DataType(DataType.Date)]

        public DateTime DateSortie { get; set; }
        public string Image { get; set; }
        public string? Description { get; set; }

        // Reference 1 vers n Evenement
        public ICollection<Evenement> Evenements{ get; set; }

        // Reference n vers n Fabricant
        public ICollection<Fabricant> Fabricants { get; set; }

        // Reference n vers n Personnage
        public ICollection<Personnage> Personnages { get; set; }

        public Jeu()
        {
            this.Evenements = new HashSet<Evenement>();
            this.Fabricants = new HashSet<Fabricant>();
            this.Personnages = new HashSet<Personnage>();
        }
    }
}
