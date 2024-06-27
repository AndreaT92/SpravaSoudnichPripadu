using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public enum Specializace
    {
        [Description("Civilní právo")]
        CivilniPravo,

        [Description("Trestní právo")]
        TrestniPravo,

        [Description("Insolvenční právo")]
        InsolvencniPravo,
    }
 
}
