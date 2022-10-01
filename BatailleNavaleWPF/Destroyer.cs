using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavaleWPF
{
    public class Destroyer : Navire
    {
        public Destroyer(Case[] carres) : base("Destroyer", carres)
        {
        }
    }
}
