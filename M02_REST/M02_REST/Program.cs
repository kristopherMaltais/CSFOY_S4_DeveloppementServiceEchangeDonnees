using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

class Program
{
    private static HttpClient _httpClient = new HttpClient();
    private static string _uriRechercheParAuteur = "/query.json?type=/type/edition&authors=/authors/{refAuteur}&*=";
    static void Main(string[] args)
    {
        Task<List<Livre>> res = Requete("0L44388A");
        res.Wait();
        res.Result.ForEach(livre => Console.Out.WriteLine(livre.title));
    }

    private static async Task<List<Livre>> Requete(string p_auteur)
    {
        List<Livre> livres = null;

        _httpClient.BaseAddress = new Uri("http://openlibrary.org");
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await _httpClient.GetAsync(_uriRechercheParAuteur.Replace("{refAuteur}", p_auteur));

        if(response.IsSuccessStatusCode)
        {
            string contenuJSON = await response.Content.ReadAsStringAsync();
            livres = JsonConvert.DeserializeObject<List<Livre>>(contenuJSON);
        }

        return livres?? new List<Livre>();
    }

    public class Livre
    {
        public string title { get; set; }
    }
}
