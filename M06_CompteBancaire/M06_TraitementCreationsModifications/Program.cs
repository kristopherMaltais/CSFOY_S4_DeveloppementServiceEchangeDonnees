// See https://aka.ms/new-console-template for more information


using M06_BL_CompteBancaire;
using M06_FilMessages;

Producteur producteurLettresMortes = new Producteur("m06-comptes-lettres-mortes");
ActionDB actionSurBd = new ActionDB();
Consommateur consommateurComptesTransactions = new Consommateur("m06-comptes", actionSurBd, producteurLettresMortes);
consommateurComptesTransactions.TirerFilMessage();

