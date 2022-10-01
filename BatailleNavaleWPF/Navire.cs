using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavaleWPF
{
    public class Navire:INavire
    {
        public string typeNavire { get; }
        public bool Coule { get => EstCoule(); }

        private readonly Case[] cases;

        public Navire(string typeNavire, Case[] carres)
        {
            this.typeNavire = typeNavire;
            cases = carres;

            foreach (Case carre in cases)
            {
                carre.Navire = this;
            }
        }

        public bool EstCoule()
        {
            foreach (Case carre in cases)
            {
                if (!carre.Touche) return false;
            }
            return true;
        }
    }

}
