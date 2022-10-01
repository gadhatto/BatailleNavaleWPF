using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavaleWPF
{
    public class Patrouilleur : Navire
    {
        public Patrouilleur(Case[] carres) : base("Patrouilleur", carres)
        {
        }
    }
}
