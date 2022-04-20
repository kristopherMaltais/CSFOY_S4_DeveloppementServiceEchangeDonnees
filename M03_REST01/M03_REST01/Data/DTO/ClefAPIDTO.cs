using M03_REST01.Entite;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M03_REST01.Data
{
    public class ClefAPIDTO
    {
        // ** Champs ** //

        // ** Propriétés ** //
        [Key]
        [Column("CLEFAPIID")]
        public string ClefAPI { get; set; }

        // ** Constructeurs ** //
        public ClefAPIDTO()
        {
            ;
        }

        public ClefAPIDTO(ClefAPI p_clef)
        {
            this.ClefAPI = p_clef.Clef;
        }

        // ** Methodes ** //
        public ClefAPI VersEntite()
        {
            ClefAPI clefEntite = new ClefAPI(this.ClefAPI);
            return clefEntite;
        }
    }
}
