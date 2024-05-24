using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public class Zastupce : Osoba
    {
        //odvozená třída pro zástupce - je třeba k němu přiřadit účastníky a případy, ale nevím, jakou bude mít samostatnou vlastnost?
        // Může se přiřadit k účastníkovi - v jednom případu budu mít vždy aspoň dva (žalobce a žalovaný) a každý může mít svého. 

        public int CisloCak; 

    }
}
