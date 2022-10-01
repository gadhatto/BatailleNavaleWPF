using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavaleWPF
{
    class Matrice2D
    {
        // La matrice elle-même (tableau bidimensionnel en escalier)
        private Case[,] Matrice { get; }

        // Nombre de lignes de la matrice
        public int NbLignes { get => Matrice.GetLength(0); }

        // Nombre de colonnes de la matrice
        public int NbColonnes { get => Matrice.GetLength(1); }

        // L'index de départ des coordonnées (pour méthode Valeur)
        public int IndexDepart { get; set; }

        // Constructeur
        public Matrice2D(int lignes, int colonnes)
        {
            // Par défaut, l'index de départ des coordonnées est mis à 0
            IndexDepart = 0;

            try // --> manipulation de tableau
            {
                // On initialise l'espace de la matrice et on la remplit avec des null
                Matrice = new Case[lignes, colonnes];
                for (int i = 0; i < lignes; i++)
                {
                    for (int j = 0; j < colonnes; j++)
                    {
                        Matrice[i,j] = null;
                    }
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"[Matrice2D] Erreur initialisation de la matrice: {e.Message}");
            }
        }

        public Case GetValeur(int i, int j)
        {
            // Les index fournis doivent être dans les plages permises en fonction de l'index de départ
            if (i < IndexDepart || i >= NbLignes + IndexDepart ||
                j < IndexDepart || j >= NbColonnes + IndexDepart)
            {
                throw new InvalidOperationException($"[Matrice2D.Valeur({i},{j})] Indices hors plage");
            }

            try // --> manipulation de tableau
            {
                return Matrice[i - IndexDepart, j - IndexDepart];
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"[Matrice2D.Valeur({i},{j})] {e.Message}");
            }
        }

        public void SetValeur(int i, int j, Case carre)
        {
            // Les index fournis doivent être dans les plages permises en fonction de l'index de départ
            if (i < IndexDepart || i >= NbLignes + IndexDepart ||
                j < IndexDepart || j >= NbColonnes + IndexDepart)
            {
                throw new InvalidOperationException($"[Matrice2D.Valeur({i},{j})] Indices hors plage");
            }

            try // --> manipulation de tableau
            {
                Matrice[i - IndexDepart, j - IndexDepart] = carre;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"[Matrice2D.Valeur({i},{j})] {e.Message}");
            }
        }
    }
}
