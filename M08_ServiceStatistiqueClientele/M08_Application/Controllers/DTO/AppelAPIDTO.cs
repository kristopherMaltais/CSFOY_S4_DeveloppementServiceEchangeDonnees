using M08_Application.Entite;

namespace M08_Application.Controllers.DTO
{
    public class AppelAPIDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public Guid? IdentifiantAppel { get; set; }
        public int? IdentifiantAgent { get; set; }
        public DateTime? DebutAppel { get; set; }
        public DateTime? FinAppel { get; set; }

        // ** Constructeurs ** //
        public AppelAPIDTO()
        {
            ;
        }

        // ** Méthodes ** //
       public Appel VersIdentite()
       {
            return new Appel(this.IdentifiantAgent);
       }
    }
}
