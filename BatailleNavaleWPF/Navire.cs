using System;

namespace BatailleNavale
{
    class Navire
    {
<<<<<<< Updated upstream
        public TypeNavire Type { get; }
=======
        //Declaration de variable
        public string typeNavire { get; }
>>>>>>> Stashed changes
        public bool Coule { get => EstCoule(); }

        private readonly Case[] cases;

        public Navire (TypeNavire type, Case[] carres)
        {
            Type = type;
            cases = carres;

            foreach (Case carre in cases)
            {
                carre.Navire = this;
            }
        }

        private bool EstCoule()
        {
            foreach (Case carre in cases)
            {
                if (!carre.Touche) return false;
            }
            return true;
        }
    }
}
