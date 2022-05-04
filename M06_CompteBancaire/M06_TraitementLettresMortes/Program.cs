// See https://aka.ms/new-console-template for more information
using M06_FilMessages;

ActionFichierBinaire actionSurFichierBinaire = new ActionFichierBinaire();
Consommateur consommateurLettresMortes = new Consommateur("m06-comptes-lettres-mortes", actionSurFichierBinaire);
consommateurLettresMortes.TirerFilMessage();
