namespace SpravaSoudnichPripadu.osoby
{
    public abstract class Osoba
    {
        //základní třída pro všechny osoby
        public string? Jmeno { get; set; }
        public string? Prijmeni { get; set; }
        public string? Adresa { get; set; }

        public override string ToString()
        {
            return $"Jméno: {Jmeno}, Příjmení: {Prijmeni}, Adresa: {Adresa}";
        }
    }
}
