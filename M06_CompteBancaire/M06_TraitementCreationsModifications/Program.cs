// See https://aka.ms/new-console-template for more information


using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;

IDepot depotTest = new DepotCompteBancaire(DbContextGeneration.ObtenirApplicationDBContext());
ManipulerCompteBancaire manipuler = new ManipulerCompteBancaire(depotTest);

IEnumerable<Compte> compte1 = manipuler.ObtenirComptes();

Console.WriteLine(compte1.First().TypeCompte);
