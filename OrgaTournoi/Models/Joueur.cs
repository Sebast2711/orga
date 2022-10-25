using System.Globalization;

namespace OrgaTournoi.Models
{
    public class Joueur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pseudo { get; set; }

        // Reference au pays
        public int PaysId { get; set; }
        public Pays Pays { get; set; }


        public string? Description { get; set; }
        public string CashprizeTotal { get; set; }
        public int Age { get; set; }

        // Reference n vers n Equipe
        //public ICollection<Equipe> Equipes { get; set; }
        // Asssociation EquipeJoueur
        public List<EquipeJoueur> EquipesJoueurs { get; set; }

        public Joueur()
        {
            //this.Equipes = new HashSet<Equipe>();
        }

    }
}
