/**
 * Application de test de la fonction 'Polonaise'
 * author : Emds
 * date : 20/06/2020
 */
using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        static Double Polonaise(string formule)
        {
            try
            {
                string[] tab = formule.Split(' ');
                int nbCases = tab.Length;

                while (nbCases > 1)
                {
                    int k = nbCases - 1;
                    while (k > 0 && tab[k] != "+" && tab[k] != "-" && tab[k] != "*" && tab[k] != "/")
                    {
                        k--;
                    }
                    float a = float.Parse(tab[k + 1]);
                    float b = float.Parse(tab[k + 2]);
                    switch (tab[k])
                    {
                        case "+":
                            tab[k] = (a + b).ToString();
                            break;
                        case "-":
                            tab[k] = (a - b).ToString();
                            break;
                        case "*":
                            tab[k] = (a * b).ToString();
                            break;
                        case "/":
                            if (b == 0)
                            {
                                return Double.NaN;
                            }
                            tab[k] = (a / b).ToString();
                            break;
                    }
                    for (int j = k + 1; j < nbCases - 2; j++)
                    {
                        tab[j] = tab[j + 2];
                    }
                    // les cases suivantes sont mises à blanc
                    for (int j = nbCases - 2; j < nbCases; j++)
                    {
                        tab[j] = " ";
                    }
                    nbCases = nbCases - 2;
                }
                return Double.Parse(tab[0]);
            }
            catch
            {
                return Double.NaN;
            }
        }
        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
