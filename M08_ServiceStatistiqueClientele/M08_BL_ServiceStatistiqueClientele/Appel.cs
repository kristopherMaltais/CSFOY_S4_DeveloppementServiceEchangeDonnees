namespace M08_Application.Entite
{
    public class Appel
    {
        // Champs ** //

        // ** Propriétés ** //
        public Guid? IdentifiantAppel { get; set; }
        public int? IdentifiantAgent { get; set; }
        public DateTime? DebutAppel { get; set; }
        public DateTime? FinAppel { get; set; }

        // ** Constructeur ** //
        public Appel(int? p_identifiantAgent)
        {
            this.IdentifiantAgent = p_identifiantAgent;
            this.IdentifiantAppel = Guid.NewGuid();
            this.DebutAppel = DateTime.Now;
        }

        // ** Méthodes ** //
    }
}
