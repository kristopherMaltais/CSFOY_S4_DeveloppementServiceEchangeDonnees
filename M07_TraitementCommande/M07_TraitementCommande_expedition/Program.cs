﻿// See https://aka.ms/new-console-template for more information

using M07_TraitementCommande_FIlMessage;

Subscriber consommateur = new Subscriber("m07-preparation-expedition", "m07-commandes", "commande.placee.*", new ActionExpedition());
consommateur.TirerMessage();

