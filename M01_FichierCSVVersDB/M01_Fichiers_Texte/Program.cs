// See https://aka.ms/new-console-template for more information

using M01_DAL_Import_Munic_CSV;
using M01_Srv_Municipalite;
using M01_DAL_MunicipaliteSQLServer;
using System.Text.RegularExpressions;
using M01_DAL_Municipalite_SQLServer;
using BibliothequeDAL;

string test;
string path = "C:\\info\\S4\\CSFOY_S4_DeveloppementServiceEchangeDonnees\\MUN.csv";

IDepotImportationMunicipalite depot = new DepotImportationMunicipalite(path);

IEnumerable<Municipalite> municipals = depot.LireMunicipalite();


DbContextGeneration.ObtenirApplicationDBContext();


IDepotMunicipalite depotbd = new DepotMunicipalite(DbContextGeneration.ObtenirApplicationDBContext());

//foreach (Municipalite municipalite in municipals)
//{
//    depotbd.AjouterMunicipalite(municipalite);
//}


IEnumerable<Municipalite> listeMunicipaliteActive = depotbd.ListerMunicipaliteActives();

foreach (Municipalite municipalite in listeMunicipaliteActive)
{
    Console.WriteLine(municipalite);
}


