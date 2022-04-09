using M02_BL_Meteo;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using M02_Meteo_JSONStructure;

namespace M02_DAL_ImportMeteo_REST
{
    public class DepotRechercheMeteo : IDepotMeteo
    {
        // ** Champs ** //
        private HttpClient _httpClient = new HttpClient();
        // ** Propriétés ** //

        // ** Constructeurs ** //

        // ** Méthodes ** //
        public ICollection<Ville> RechercherMeteoCoordonnees(float p_latitude, float p_longitude)
        {
            ICollection<Ville> resultatJSON = null;

            _httpClient.BaseAddress = new Uri("https://www.metaweather.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> res = _httpClient.GetAsync($"https://www.metaweather.com/api/location/search/?lattlong={p_latitude},{p_longitude}");
            res.Wait();

            if (res.Result.IsSuccessStatusCode)
            {
                Task<string> tache = res.Result.Content.ReadAsStringAsync();
                tache.Wait();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                resultatJSON = JsonConvert.DeserializeObject<ICollection<Ville>>(tache.Result, settings);
            }

            return resultatJSON;
        }

        public ICollection<Meteo> RechercherMeteoNomVille(string p_nomVille)
        {
            ICollection<Ville> resultatJSON = null;
            _httpClient.BaseAddress = new Uri("https://www.metaweather.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> res = _httpClient.GetAsync($"https://www.metaweather.com//api/location/search/?query={p_nomVille}");
            res.Wait();

            if (res.Result.IsSuccessStatusCode)
            {
                Task<string> tache = res.Result.Content.ReadAsStringAsync();
                tache.Wait();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                resultatJSON = JsonConvert.DeserializeObject<ICollection<Ville>>(tache.Result, settings);
            }

            return RechercherMeteo(resultatJSON.First());

        }

        private ICollection<Meteo> RechercherMeteo(Ville p_ville)
        {
            RacineMeteo resultatJSON = null;
            _httpClient.BaseAddress = new Uri("https://www.metaweather.com");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Task<HttpResponseMessage> res = _httpClient.GetAsync($"https://www.metaweather.com//api/location/{p_ville.woeid}");
            res.Wait();

            if (res.Result.IsSuccessStatusCode)
            {
                Task<string> tache = res.Result.Content.ReadAsStringAsync();
                tache.Wait();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                };

                resultatJSON = JsonConvert.DeserializeObject<RacineMeteo>(tache.Result, settings);
            }

            return resultatJSON.Consolided.Meteo;

        }
    }
}