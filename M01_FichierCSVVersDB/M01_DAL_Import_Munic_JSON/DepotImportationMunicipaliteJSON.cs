using M01_DAL_Municipalite_SQLServer.DTO;
using M01_Srv_Municipalite;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace M01_DAL_Import_Munic_JSON
{
    public class DepotImportationMunicipaliteJSON : IDepotImportationMunicipalite
    {
        // ** Champs ** //
        private string m_nomFichier;

        // ** propriétés ** //

        // ** Constructeurs ** //
        public DepotImportationMunicipaliteJSON(string p_chemin)
        {
            this.m_nomFichier = p_chemin;
        }

        // ** Méthodes ** //
        public Dictionary<int, Municipalite> ListerMunicipalite()
        {
            return DeserializerClients();
        }
        private Dictionary<int, Municipalite> DeserializerClients()
        {
            Racine resultatJSON = null;
            DateTime dateNull = new DateTime(0001, 01, 01);
            Dictionary<int, Municipalite> dictionnaireARetourner = new Dictionary<int, Municipalite>(); 

            if (File.Exists(this.m_nomFichier))
            {
                string chaineJSON = File.ReadAllText(this.m_nomFichier);
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                resultatJSON = JsonConvert.DeserializeObject<Racine>(chaineJSON, settings);
            }

            dictionnaireARetourner = resultatJSON.Result.Records.ToDictionary(resultat => resultat.Mcode, resultat => resultat.VersEntite());

            return dictionnaireARetourner;
        }
    }
}