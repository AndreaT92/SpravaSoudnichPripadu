namespace SpravaSoudnichPripadu
{
    internal class LogikaFiltrovani
    {
        // toto je třída pro vytvoření logiky pro interakci s uživatelem (UI) a pro výběr akcí  (co se bude ukazovat uživateli a jak se to bude chovat)
        // zpracování vstupů a výpis výsledků
        
        private SpravaPripadu spravaPripadu;

        public LogikaFiltrovani(SpravaPripadu spravaPripadu)
        {
            this.spravaPripadu = spravaPripadu;
        }

        public void Spustit() // metoda pro zobrazení výběru možností + potřebuji přidat case na přidání případu
                              // ještě by se mi líbilo hledání osob a informací o nich  + případy, ve kterých se vyskytují 
                              
        {
            while (true)
            {
                Console.WriteLine("Vyberte akci:");
                Console.WriteLine("1 - Najít případ dle čísla");
                Console.WriteLine("2 - Filtrovat případy podle kritérii");
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
                        NajitPripadPodleCisla(); 
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

        private void NajitPripadPodleCisla() // metoda, která vyhledá případ podle čísla 
        {
            Console.Write("Zadejte číslo případu: ");
            if (int.TryParse(Console.ReadLine(), out int cisloPripadu))
            {

                var nalezenyPripad = spravaPripadu.NajitPripadPodleCisla(cisloPripadu);
                if (nalezenyPripad == null)
                {
                    Console.WriteLine("Případ nenalezen.");
                    return;
                }
                Console.WriteLine($"Nalezený případ: {nalezenyPripad.Popis}. " +
                                      $"Soudce: {nalezenyPripad.Soudci.Jmeno} {nalezenyPripad.Soudci.Prijmeni}. " +
                                      $"Specializace: {nalezenyPripad.Soudci.Specializace}." +
                                      $"Jednání nařízeno na den: {nalezenyPripad.DatumJednani}. " +
                                      $"Případ skončen: {nalezenyPripad.JeSkonceno}. "); ; ;
                Console.WriteLine("Účastníci řízení:");
                foreach (var ucastnik in nalezenyPripad.Ucastnici)
                {
                    Console.WriteLine($"- {ucastnik.Jmeno} {ucastnik.Prijmeni}, Adresa: {ucastnik.Adresa}, Role: {ucastnik.roleVRizeni}");
                }
                Console.WriteLine();
                Console.WriteLine("Zástupci:");
                foreach (var zastupce in nalezenyPripad.Zastupci)
                {
                    Console.WriteLine($"- {zastupce.Jmeno} {zastupce.Prijmeni}, Adresa: {zastupce.Adresa}, ČAK: {zastupce.cak}, Role: {zastupce.RoleVRizeniZastupce}");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Neplatné číslo případu. Zadejte prosím platné číslo.");
                Console.WriteLine();
            }
        }


        private void FiltrovatPripady() // metoda pro samotné filtrování a vyhledání případu
        {
            DateTime? datumJednani = HledaniPodleDataJednani();
            bool? jeSkonceno = HledaniPodleStavu();
            string soudce = NajitPodleOsoby("Zadejte jméno a příjmení soudce nebo nechte prázdné: ");
            string zastupce = NajitPodleOsoby("Zadejte jméno a příjemní zástupce nebo nechte prázdné: ");
            string ucastnik = NajitPodleOsoby("Zadejte jméno a příjmení účastníka nebo nechte prázdné: ");


            // přidat filtr dle účastníka, sop zaplacen...

            var filtrovanePripady = spravaPripadu.FiltrovatPripady(datumJednani, jeSkonceno, soudce, zastupce, ucastnik);
            if (filtrovanePripady.Any())  // nemanipuluju tady s daty, tak jsem použila if else
            {
                foreach (var prip in filtrovanePripady) // cyklus pro vypsání nalezených případů
                {
                    Console.WriteLine($"Případ {prip.CisloPripadu}: {prip.Popis}, Datum jednání: {prip.DatumJednani}, Soudce: {prip.Soudci.Jmeno} {prip.Soudci.Prijmeni}, Skončeno: {prip.JeSkonceno}");
                    Console.WriteLine("Účastníci řízení:");
                    foreach (var ucastnikPripadu in prip.Ucastnici)
                    {
                        Console.WriteLine($"- {ucastnikPripadu.Jmeno} {ucastnikPripadu.Prijmeni}, Adresa: {ucastnikPripadu.Adresa}, Role: {ucastnikPripadu.roleVRizeni}");
                    }
                    Console.WriteLine("Zástupci:");
                    foreach (var zastupcePripadu in prip.Zastupci)
                    {
                        Console.WriteLine($"- {zastupcePripadu.Jmeno} {zastupcePripadu.Prijmeni}, Adresa: {zastupcePripadu.Adresa}, ČAK: {zastupcePripadu.cak}, Role: {zastupcePripadu.RoleVRizeniZastupce}");
                    }
                }

            }
            else
            {
                Console.WriteLine("Žádný takový případ nebyl nalezen.");
                Console.WriteLine();
            }
        }

        private static bool? HledaniPodleStavu() // metoda pro ošetření vstupu pro hledání dle stavu 
        {
            bool? jeSkonceno = null;

            do
            {
                Console.Write("Zadejte stav skončení případu (true/false) nebo nechte prázdné: "); // filtr podle stavu
                var stavHledany = Console.ReadLine();

                if (string.IsNullOrEmpty(stavHledany))
                {
                    break; 
                }

                if (bool.TryParse(stavHledany, out bool parsedBool))
                {
                    jeSkonceno = parsedBool;
                }
                else
                {
                    Console.WriteLine("Chybný formát. Zadejte prosím 'true' nebo 'false'.");
                }
            } while (jeSkonceno == null);
            return jeSkonceno;
        }

        private static DateTime? HledaniPodleDataJednani() // metoda pro ošetření vstupu pro hledání podle data jednání
        {
            DateTime? datumJednani = null;

            do
            {
                Console.Write("Zadejte datum jednání (YYYY-MM-DD) nebo nechte prázdné: "); 
                var datumHledane = Console.ReadLine();

                if (string.IsNullOrEmpty(datumHledane))
                {
                    break;
                }

                if (DateTime.TryParse(datumHledane, out DateTime parsedDate))
                {
                    datumJednani = parsedDate;
                }
                else
                {
                    Console.WriteLine("Chybný formát data. Zadejte prosím datum ve formátu YYYY-MM-DD.");

                }
            } while (datumJednani == null);
            return datumJednani;
        }

        private void OdebratPripad() // metoda pro odebrání případu podle čísla
        {
            Console.Write("Zadejte číslo případu k odstranění: ");
            if (int.TryParse(Console.ReadLine(), out int cisloPripaduOdebrat))
            {
                 bool povedloSe = spravaPripadu.OdebratPripad(cisloPripaduOdebrat);
                if (povedloSe)
                {
                    Console.WriteLine("Případ byl úspěšně odstraněn.");
                }
                else
                {
                    Console.WriteLine("Žádný takový případ nebyl nalezen.");
                    Console.WriteLine();
                }
            }
        }
        private static string NajitPodleOsoby(string pokynKZadani)
        {
            while (true)
            {
                Console.Write(pokynKZadani);
                var jmeno = Console.ReadLine();

                if (string.IsNullOrEmpty(jmeno))
                {
                    return null;
                }

                if (JeJmenoSpravne(jmeno))
                {
                    return jmeno.ToLower();
                }
                else
                {
                    Console.WriteLine("Neplatné jméno. Zadejte pouze písmena a mezery.");
                }
            }
        }

        private static bool JeJmenoSpravne(string jmeno)
        {
            foreach (char c in jmeno)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
