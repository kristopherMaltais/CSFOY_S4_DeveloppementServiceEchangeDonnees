// See https://aka.ms/new-console-template for more information

using M01_DAL_Import_Munic_CSV;
using M01_Srv_Municipalite;
using M01_DAL_MunicipaliteSQLServer;
using System.Text.RegularExpressions;
using M01_DAL_Municipalite_SQLServer;
using BibliothequeDAL;

string test;
string path = "C:\\info\\S4\\CSFOY_S4_DeveloppementServiceEchangeDonnees\\M01_Municipalite\\MUN.csv";

IDepotImportationMunicipalite depot = new DepotImportationMunicipalite(path);

IEnumerable<Municipalite> municipals = depot.LireMunicipalite();


DbContextGeneration.ObtenirApplicationDBContext();


IDepotMunicipalite depotbd = new DepotMunicipalite(DbContextGeneration.ObtenirApplicationDBContext());

//foreach (Municipalite municipalite in municipals)
//{
//    depotbd.AjouterMunicipalite(municipalite);
//}

//Municipalite testmuni = depotbd.ChercherMunicipaliteParCodeGeographique(1023);
//Console.WriteLine(testmuni);

Municipalite testDesactiver = new Municipalite(1023, "Les Îles-de-la-Madeleine", "direction@muniles.ca", "www.muniles.ca", new DateTime(2025, 11, 02), true);

depotbd.DesactiverMunicipalite(testDesactiver);


