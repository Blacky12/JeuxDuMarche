using System;
using System.ComponentModel.Design;
using System.Runtime.Versioning;

class Program
{
    static string[] fruits;
    static void Main()
    {

        int num = -1;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\t\t\t Jeux du Marché");
            Console.WriteLine("1. Ajouter");
            Console.WriteLine("2. Afficher");
            Console.WriteLine("3. Retirer");
            Console.WriteLine("4. Rechercher");
            Console.WriteLine("0. Quitter ");
            Console.WriteLine("\n Veuillez faire un choix");

            string chx = Console.ReadLine();

            try
            {
                int chxParse = int.Parse(chx);
                if (chxParse.Equals(1))
                {
                    Ajouter();
                    Console.WriteLine();
                }
                else if (chxParse.Equals(2))
                {
                    Afficher();
                    Console.WriteLine();
                }
                else if (chxParse.Equals(3))
                {
                    Retirer();
                    Console.WriteLine();
                }
                else if (chxParse.Equals(4))
                {
                    Rechercher();
                }
                else if (chxParse.Equals(0))
                {
                    Console.WriteLine("A bientôt !");
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Option invalide. Veuillez choisir 0 ou 1.");
                }
            }
            catch (System.Exception)
            {

                Console.WriteLine("Erreur:Veuillez entrer un  nombre valide.. Ex:0,1");
            }
        }

    }

    public static void Ajouter()
    {
        fruits = new string[5];

        for (int i = 0; i < fruits.Length; i++)
        {
            Console.WriteLine("Veuillez choisir vos fruit et légume");
            string chx = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(chx))
            {
                Console.WriteLine("Veuillez choisir un fruit ou légume: ");
                chx = Console.ReadLine();
            }

            fruits[i] = chx;
        }

        bool doublonFind = false;

        for (int i = 0; i < fruits.Length; i++)
        {
            for (int j = i + 1; j < fruits.Length; j++)
            {
                if (fruits[i] == fruits[j])
                {
                    Console.WriteLine("Vous avec un même fruis dans votre panier");
                    Console.WriteLine($"Doublon trouvé à l'index: {fruits[i]} à l'index {i} et {j}. \n Veuillez changé le doublon ");
                    string doublon = fruits[i];
                    doublonFind = true;
                    fruits[i] = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("C'est le même fruits veuillez le modifier");
                        fruits[i] = Console.ReadLine();
                    } while (fruits[i] == doublon);
                }
            }
        }

        if (!doublonFind)
        {
            Console.WriteLine("Aucun doublon trouvé");
        }

        Thread.Sleep(2000);

    }

    static void Afficher()
    {
        if (fruits == null || fruits.Length == 0)
        {
            Console.WriteLine("Votre Panier est vide. Dans le menu selectionnez \"Ajouter \" pour le remplir");
            Console.WriteLine("");
            Thread.Sleep(4000);
        }
        else
        {
            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
            }
        }

        Console.WriteLine("Retour au menu dans 5 secondes");
        Thread.Sleep(4000);
    }

    static void Retirer()
    {


        if (fruits == null || fruits.Length == 0)
        {
            Console.WriteLine("Votre Panier est vide");
        }
        else
        {

            Console.WriteLine("Voici votre panier");
            foreach (var fruit in fruits)
            {
                Console.WriteLine($"{fruit}");
            }

            bool fruitFind = false;
            Console.WriteLine("Quel fruits voulez vous supprimer ?");
            string fruitDelete = Console.ReadLine();

            while (!fruitFind)
            {
                for (int i = 0; i < fruits.Length; i++)
                {

                    if (fruits[i].Equals(fruitDelete, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine(fruits[i] + " à été supprimé");
                        fruits[i] = "";
                        fruitFind = true;
                    }
                }

                if (!fruitFind)
                {
                    Console.WriteLine("Fruit introuvable. Retirer un fruit dans votre panier");
                    fruitDelete = Console.ReadLine();
                }
            }
        }
    }
    static void Rechercher()
    {

        bool flag = false;
        string recherche = "";
        while (!flag)
        {
            Console.WriteLine("Quel fruit voulez vous reherché ?");
            recherche = Console.ReadLine();
            for (int i = 0; i < fruits.Length; i++)
            {
                if (fruits[i].Equals(recherche, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Le fruit {fruits[i]} est bien dans votre panier et c'est votre {i + 1} ième article");
                    flag = true;
                    Thread.Sleep(1000);

                }
            }
            if (!flag)
            {
                Console.WriteLine("Le fruit recherché n'est pas dans votre panier \n Rechercher un nouveau fruit ? (y/n)"); 
                var answers = Console.ReadLine();

                if (answers == "y")
                {
                   flag = false;
                }
                else if (answers == "n")
                {
                    Console.WriteLine("Retour au menu");
                    flag = true;
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Veuillez taper y ou n");
                }
            }
        }
    }
}