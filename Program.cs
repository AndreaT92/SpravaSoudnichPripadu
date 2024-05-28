using SpravaSoudnichPripadu.osoby;
using System.Collections.Generic;

namespace SpravaSoudnichPripadu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Cílem projektu je vytvořit aplikaci pro správu soudních případů,
            //která umožní soudům sledovat a filtrovat jednotlivé případy,
            //účastníky soudních řízení, termíny soudních jednání a časem možná i relevantní dokumenty.

            // výjimky - přes try catch? 

            // filtrovani jednani dle různych kriterii (datum, stav, soudce...) - přes metodu ve spec. class?

            // ráda bych, aby byl Main co nejkratší, takže se mi nelíbí zadávání případů v main metodě. Zatím to tak mám pro test funkčnosti.
            // Kdybychom měli případů sto, tak jak by to vypadalo. Chtěla bych nějaké defaultní případy od spuštění
            // a plus možnost zadat nové od uživatele a aby si je to pak tedy uchovalo. 

            var spravaPripadu = new SpravaPripadu();
            spravaPripadu.PridatPreddefinovanePripady();

            try
            {
                
                var logikaFiltrovani = new LogikaFiltrovani(spravaPripadu);

                // spuštění filtrovací metody 

                logikaFiltrovani.Spustit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Došlo k chybě: {ex.Message}");
            }

        }
    }
}
