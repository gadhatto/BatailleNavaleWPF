using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatailleNavaleWPF
{
    public interface INavire
    {
        string typeNavire { get; }
        bool Coule { get; }

        bool EstCoule();
    }
}
