// See https://aka.ms/new-console-template for more information

using M02_BL_Meteo;
using M02_DAL_ImportMeteo_REST;

IDepotMeteo depot = new DepotRechercheMeteo();


ICollection<Meteo> meteotest = depot.RechercherMeteoNomVille("london");

foreach(Meteo meteo in meteotest)
{
    Console.WriteLine(meteo.ToString());
}