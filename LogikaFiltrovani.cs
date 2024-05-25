namespace SpravaSoudnichPripadu
{
    internal class LogikaFiltrovani
    {
        // toto je třída pro vytvoření logiky pro interface (co se bude ukazovat uživateli a jak se to bude chovat)
        // vytvořit základní abstract class pro LogikuFiltrovani a SpravuPripadu a Pripady? Abstract metody NajitPripad + FiltrovatPripady + OdebratPripad?
        private SpravaPripadu spravaPripadu;

        public LogikaFiltrovani(SpravaPripadu spravaPripadu)
        {
            this.spravaPripadu = spravaPripadu;
        }

        public void Spustit() // metoda pro zobrazení výběru možností + potřebuji přidat case na přidání případu
        {
            while (true)
            {
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1 - Najít případ dle čísla");
                Console.WriteLine("2 - Filtrovat případy podle kritérii");
                Console.WriteLine("3 - Odstranit případ dle čísla");
                Console.WriteLine("4 - Konec");
                // ještě by se mi líbilo hledání osob a informací o nic  + případy, ve kterých se vyskytují 
                var akce = Console.ReadLine();

                if (akce == "4")
                {
                    break;
                }

                switch (akce)
                {
                    case "1":
                        NajitPripad();
                        break;
                    case "2":
                        FiltrovatPripady();
                        break;
                    case "3":
                        OdebratPripad();
                        break;
                    default:
                        Console.WriteLine("Neplatná akce.");
                        break;
                }
            }
        }

        private void NajitPripad() // metoda, která vyhledá případ  - je matoucí, že se to jmenuje stejně jako metody ve SpravaPripadu?
        {
            Console.Write("Zadejte číslo případu: ");
            if (int.TryParse(Console.ReadLine(), out int cisloPripadu))
            {
                try
                {
                    var nalezenyPripad = spravaPripadu.NajitPripad(cisloPripadu);
                    Console.WriteLine($"Nalezený případ: {nalezenyPripad.Popis}. Soudní poplatek zaplacen: {nalezenyPripad.SopZaplacen}. Jednání nařízeno na den: {nalezenyPripad.DatumJednani}. Případ skončen: {nalezenyPripad.JeSkonceno}. ");
                    
                }
                catch (Exception ex) // asi zbytečné, kdyz to mam ošetřeno uz ve SpravePripadu? Ale tam když to spadne, tak je to jako vyjimka a nemůže hledat dál... 
                {
                    Console.WriteLine("Žádný takový případ nebyl nalezen.");
                    Console.WriteLine(); 
                }
            }
            else
            {
                Console.WriteLine("Neplatné číslo případu. Zadejte prosím platné číslo.");
                Console.WriteLine();
            }
        }

        // logika na filtrování případů - podle všeho chci? Chci podle všech parametrů? 
        // vytvořit metodu pro každou položku filtrování zvlášť pro větší přehlednost??
        private void FiltrovatPripady() // metoda pro samotné filtrování a vyhledání, vygooglila jsem si nullable pro ošetření vstupu.. co ale když zadá špatně datetime? umožnit jim to zadat znovu? Nutno přepsat :D 
        {
            Console.Write("Zadejte datum jednání (YYYY-MM-DD) nebo nechte prázdné: "); // filtr podle jednání
            var datumInput = Console.ReadLine();
            DateTime? datumJednani = string.IsNullOrEmpty(datumInput) ? (DateTime?)null : DateTime.Parse(datumInput);

            Console.Write("Zadejte stav skončení případu (true/false) nebo nechte prázdné: "); // filtr podle stavu
            var stavInput = Console.ReadLine();
            bool? jeSkonceno = string.IsNullOrEmpty(stavInput) ? (bool?)null : bool.Parse(stavInput);

            Console.Write("Zadejte jméno soudce nebo nechte prázdné: "); // filtr dle soudce, dopárovat s metodami JeJmenoSpravne a ZmensiPismeno
            var soudce = Console.ReadLine();

            Console.Write("Zadejte jméno zástupce nebo nechte prázdné: "); // filtr dle zástupce, dopárovat s metodami JeJmenoSpravne a ZmensiPismeno
            var zastupce = Console.ReadLine();

            // přidat filtr dle účastníka, sop zaplacen... 

            var filtrovanePripady = spravaPripadu.FiltrovatPripady(datumJednani, jeSkonceno, soudce, zastupce);
            if (filtrovanePripady.Any())  // nemanipuluju tady s daty, tak jsem použila 
            {
                foreach (var prip in filtrovanePripady) // cyklus pro vypsání nalezených případů
                {
                    Console.WriteLine($"Případ {prip.CisloPripadu}: {prip.Popis}, Datum jednání: {prip.DatumJednani}, Soudce: {prip.Soudci.Jmeno} {prip.Soudci.Prijmeni}, Skončeno: {prip.JeSkonceno}");
                }
            }
            else
            {
                Console.WriteLine("Žádný takový případ nebyl nalezen.");
                Console.WriteLine();
            }
        }

        private void OdebratPripad() // metoda pro odebrání případu
        {
            Console.Write("Zadejte číslo případu k odstranění: ");
            if (int.TryParse(Console.ReadLine(), out int cisloPripaduOdebrat))
            {
                try
                {
                    spravaPripadu.OdebratPripad(cisloPripaduOdebrat);
                    Console.WriteLine("Případ byl úspěšně odstraněn.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Žádný takový případ nebyl nalezen.");
                    Console.WriteLine();
                }
            }
        }
        //    //private string ZmensiPismeno(string prompt) - metoda na podchycení špatně zadaného malého písmena u jména - doplnit do FiltrovatPripady
        //    //{
        //    //    while (true)
        //    //    {
        //    //        Console.Write("Zadejte jméno: ");
        //    var jmeno = Console.ReadLine();
        //    if (IsValidName(name))
        //    {
        //        return string.IsNullOrEmpty(name) ? null : name.ToLower(); // Normalizace na malá písmena
        //    }
        //Console.WriteLine("Neplatné jméno. Zadejte pouze písmena a mezery.");
        //    //    }
        //}

        //private bool jeJmenoSpravne(string jmeno) - metoda na kontrolu, zda bylo zadáno jméno správně - doplnit do FiltrovatPripady
        //{
        //    if (string.IsNullOrEmpty(jmeno))
        //    {
        //        return true; // Prázdný vstup je povolen
        //    }
        //    foreach (char c in jmeno)
        //    {
        //        if (!char.IsLetter(c) && c != ' ')
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}


    }
}

