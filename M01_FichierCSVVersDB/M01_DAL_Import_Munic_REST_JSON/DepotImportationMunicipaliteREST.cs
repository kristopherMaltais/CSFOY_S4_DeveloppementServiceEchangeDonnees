using M01_DAL_Import_Munic_JSON;
using M01_Srv_Municipalite;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace M01_DAL_Import_Munic_REST_JSON
{
    public class DepotImportationMunicipaliteREST : IDepotImportationMunicipalite
    {
        // ** Champs ** //
        private static HttpClient _httpClient;
        private static string _uri = "https://www.donneesquebec.ca/recherche/api/action/datastore_search?resource_id=19385b4e-5503-4330-9e59-f998f5918363&limit=3000";
        // ** Propriétés ** //

        // ** Constructeurs ** //
        public DepotImportationMunicipaliteREST()
        {
            _httpClient = new HttpClient();
        }

        // ** Méthodes ** //
        public Dictionary<int, Municipalite> ListerMunicipalite()
        {
            Racine resultatJSON = null;
            Dictionary<int, Municipalite> dictionnaireARetourner = new Dictionary<int, Municipalite>();

            _httpClient.BaseAddress = new Uri("https://www.donneesquebec.ca");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> res = _httpClient.GetAsync(_uri);
            res.Wait();

            if (res.Result.IsSuccessStatusCode)
            {
                Task<string> tache = res.Result.Content.ReadAsStringAsync();
                tache.Wait();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                resultatJSON = JsonConvert.DeserializeObject<Racine>(tache.Result, settings);

            }

            dictionnaireARetourner = resultatJSON.Result.Records.ToDictionary(resultat => resultat.Mcode, resultat => resultat.VersEntite());
            return dictionnaireARetourner;
        }
    }
}