﻿using System;
using System.Collections.Generic;

namespace BatailleNavaleWPF
{
    class Grille
    {
        static private readonly Random rnd = new Random();

        private readonly char[] lignes =
        { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private const int maxNbColonnes = 100;

        private const int tailleGrilleDefaut = 10;

        public int NbLignes { get; }
        public int NbColonnes { get; }

        public Matrice2D Matrice;

        // Constructeur
        public Grille(int nbLignes = tailleGrilleDefaut, int nbColonnes = tailleGrilleDefaut)
        {
            NbLignes = nbLignes >= 1 && nbLignes <= lignes.Length ? nbLignes : tailleGrilleDefaut;
            NbColonnes = nbColonnes >= 1 && nbColonnes <= maxNbColonnes ? nbColonnes : tailleGrilleDefaut;

            // Nouvelle matrice vide (aucune case occupée au départ)
            Matrice = new Matrice2D(NbLignes, NbColonnes) { IndexDepart = 1 };

            // On place les navires pour un début de partie
            Case[] cases1 = TrouverPlace(1);
            new SousMarin(cases1);
            new SousMarin(cases1);
            Case[] cases2 = TrouverPlace(2);
            new Destroyer(cases2);
            new Destroyer(cases2);
            Case[] cases3 = TrouverPlace(4);
            new Cuirasse(cases3);
            Case[] cases4 = TrouverPlace(3);
            new Patrouilleur(cases4);
            Case[] cases5 = TrouverPlace(5);
            new PorteAvions(cases5);
        }

        //private void PlacerNavire(TypeNavire typeNavire)
        //{
        //    Case[] cases = TrouverPlace((int)typeNavire);
        //    new Navire(typeNavire, cases);
        //}

        // Trouve une place vide au hasard pour le nombre de cases demandé (la méthode assume qu'il y a de la place)
        private Case[] TrouverPlace(int nbCases)
        {
            Case[] cases = new Case[nbCases];

            // Horizontal ou vertical?
            string orientation = rnd.Next(0, 2) == 0 ? "horizontal" : "vertical";

            bool placeTrouvee = false;

            // Cherche une place pour le navire
            do
            {
                // Trouve les coordonnées d'une première case (coordonnées commencent à 1)
                int ligne = rnd.Next(orientation == "horizontal" ? NbLignes : NbLignes - nbCases + 1) + 1;
                int colonne = rnd.Next(orientation == "vertical" ? NbColonnes : NbColonnes - nbCases + 1) + 1;

                // Teste la disponibilité de chaque case
                for (int i = 0; i < nbCases && CaseDisponible(ligne, colonne); i++)
                {
                    cases[i] = new Case(ligne, colonne);

                    // Change ligne ou colonne pour tester case suivante
                    if (orientation == "horizontal")
                    {
                        colonne++;
                    }
                    else
                    {
                        ligne++;
                    }

                    // Si «i» a pu se rendre jusqu'à la fin, c'est qu'il y a de la place pour le navire
                    if (i == nbCases - 1)
                    {
                        placeTrouvee = true;
                    }
                }

            } while (!placeTrouvee);

            // Ajoute les cases trouvées aux cases occupées
            SauverCases(cases);

            return cases;
        }

        // Ajoute les cases reçues en argument aux cases occupées
        private void SauverCases(Case[] cases)
        {
            foreach (Case carre in cases)
            {
                Matrice.SetValeur(carre.Position.Ligne, carre.Position.Colonne, carre);
            }
        }

        // Retourne vrai si la case à la position (ligne, colonne) n'est pas occupée
        private bool CaseDisponible(int ligne, int colonne)
        {
            return Matrice.GetValeur(ligne, colonne) == null;
        }

        // Retourne vrai + le navire si la case à la position (ligne, colonne) est occupée
        private bool GetNavire(int ligne, int colonne, out Navire navire)
        {
            bool navirePresent = false;
            navire = null;

            Case carre = Matrice.GetValeur(ligne, colonne);

            if (carre != null)
            {
                navirePresent = true;
                navire = carre.Navire;
            }

            return navirePresent;
        }

        // Retourne la grille sous forme de chaîne
        public override string ToString()
        {
            string chaine = "   ";

            for (int i = 1; i <= NbColonnes; i++)
            {
                chaine += $"{i,2} ";
            }

            chaine += "\n";

            for (int i = 1; i <= NbLignes; i++)
            {
                chaine += $"{lignes[i-1]}  ";

                for (int j = 1; j <= NbColonnes; j++)
                {
                    if (GetNavire(i, j, out Navire navire))
                    {
                        char type = ' ';
                        switch (navire.typeNavire)
                        {
                            case "Cuirasse":
                                type = 'C';
                                break;
                            case "Destroyer":
                                type = 'D';
                                break;
                            case "Patrouilleur":
                                type = 'P';
                                break;
                            case "PorteAvions":
                                type = 'A';
                                break;
                            case "SousMarin":
                                type = 'S';
                                break;
                        }
                        chaine += $" {type} ";
                    }
                    else
                    {
                        chaine += "   ";
                    }
                }

                chaine += "\n";
            }

            return chaine;
        }
    }
}
