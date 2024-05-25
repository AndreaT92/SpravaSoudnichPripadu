namespace SpravaSoudnichPripadu
{
    internal class LogikaFiltrovani
    {
        // vytvořit jase základní abstract class pro LogikuFiltrovani a SpravuPripadu a abstract metodami pripadpripad, najitpripad, odebratpripad,  list filtrovatpripady??  Mělo by to smysl? 
        private SpravaPripadu spravaPripadu;

        public LogikaFiltrovani(SpravaPripadu spravaPripadu)
        {
            this.spravaPripadu = spravaPripadu;
        }

        public void Spustit()
        {
            while (true)
            {
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1 - Najít případ dle čísla");
                Console.WriteLine("2 - Filtrovat případy");
                Console.WriteLine("3 - Odstranit případ dle čísla");
                Console.WriteLine("4 - Konec");

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

        private void NajitPripad()
        {
            Console.Write("Zadejte číslo případu: ");
            if (int.TryParse(Console.ReadLine(), out int cisloPripadu))
            {
                try
                {
                    var nalezenyPripad = spravaPripadu.NajitPripad(cisloPripadu);
                    Console.WriteLine($"Nalezený případ: {nalezenyPripad.Popis}. Soudní poplatek zaplacen: {nalezenyPripad.SopZaplacen}. Jednání nařízeno na den: {nalezenyPripad.DatumJednani}. Případ skončen: {nalezenyPripad.JeSkonceno}. ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Došlo k chybě: {ex.Message}");
                }
            }
        }

        // logika na filtrování případů - podle všeho chci? Chci podle všech parametrů? Ošetření špatných vstupů zapracovat zde (malé písmeno u jména atd..)
        private void FiltrovatPripady()
        {
            Console.Write("Zadejte datum jednání (YYYY-MM-DD) nebo nechte prázdné: ");
            var datumInput = Console.ReadLine();
            DateTime? datumJednani = string.IsNullOrEmpty(datumInput) ? (DateTime?)null : DateTime.Parse(datumInput);

            Console.Write("Zadejte stav skončení případu (true/false) nebo nechte prázdné: ");
            var stavInput = Console.ReadLine();
            bool? jeSkonceno = string.IsNullOrEmpty(stavInput) ? (bool?)null : bool.Parse(stavInput);

            Console.Write("Zadejte jméno soudce nebo nechte prázdné: ");
            var soudce = Console.ReadLine();

            Console.Write("Zadejte jméno zástupce nebo nechte prázdné: ");
            var zastupce = Console.ReadLine();

            var filtrovanePripady = spravaPripadu.FiltrovatPripady(datumJednani, jeSkonceno, soudce, zastupce);
            if (filtrovanePripady.Any())
            {
                foreach (var prip in filtrovanePripady)
                {
                    Console.WriteLine($"Případ {prip.CisloPripadu}: {prip.Popis}, Datum jednání: {prip.DatumJednani}, Soudce: {prip.Soudci.Jmeno} {prip.Soudci.Prijmeni}, Skončeno: {prip.JeSkonceno}");
                }
            }
            else
            {
                Console.WriteLine("Žádný takový případ nebyl nalezen.");
            }
        }

        private void OdebratPripad()
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
                    Console.WriteLine($"Došlo k chybě: {ex.Message}");
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
