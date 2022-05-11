// See https://aka.ms/new-console-template for more information


using M07_TraitementCommande_producteur;

Producteur producteur = new Producteur("m07-commandes");

while(true)
{
    Console.ReadLine();

    producteur.PousserMessage();
}

