// See https://aka.ms/new-console-template for more information

using M07_TraitementCommande_FIlMessage;

Subscriber consommateur = new Subscriber("m07-courriel-premium", "m07-commandes", "commande.placee.premium", new ActionCourriel());
consommateur.TirerMessage();
