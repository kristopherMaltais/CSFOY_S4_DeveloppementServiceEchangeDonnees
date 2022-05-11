// See https://aka.ms/new-console-template for more information

using M07_TraitementCommande_FIlMessage;

Subscriber consommateur = new Subscriber("m07-journal", "m07-commandes", "#", new ActionJournalisation());
consommateur.TirerMessage();