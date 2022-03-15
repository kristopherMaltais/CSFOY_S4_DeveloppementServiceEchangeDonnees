// See https://aka.ms/new-console-template for more information

using M01_DAL_Import_Munic_CSV;
using M01_Srv_Municipalite;
using M01_DAL_MunicipaliteSQLServer;
using System.Text.RegularExpressions;
using M01_DAL_Municipalite_SQLServer;
using BibliothequeDAL;
using M01_DAL_Import_Munic_JSON;



string path = "C:\\info\\S4\\CSFOY_S4_DeveloppementServiceEchangeDonnees\\M01_FichierCSVVersDB\\MUN.json";

IDepotImportationMunicipalite depot = new DepotImportationMunicipaliteJSON(path);
IDepotMunicipalite depotbd = new DepotMunicipalite(DbContextGeneration.ObtenirApplicationDBContext());

TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(depot, depotbd);

StatistiqueImportationdonnees statistique = traitement.Executer();

Console.WriteLine(statistique);


