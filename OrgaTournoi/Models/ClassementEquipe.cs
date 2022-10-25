namespace OrgaTournoi.Models
{
    public class ClassementEquipe
    {
        public int ClassementId { get; set; }
        public Classement Classement { get; set; }
        public int EquipeId { get; set; }
        public Equipe Equipe { get; set; }
        public string Cashprize { get; set; }
        public int Position { get; set; }
        public int Points { get; set; }
    }
}
