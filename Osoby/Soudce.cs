namespace SpravaSoudnichPripadu.osoby;
    using System.ComponentModel;

    // odvozená třída pro soudce 
    public class Soudce : Osoba
    {
         public Specializace Specializace { get; set; }

    public bool JeCivil => Specializace == Specializace.CivilniPravo;
    public bool JeTrest => Specializace == Specializace.TrestniPravo;
    public bool JeInsko => Specializace == Specializace.InsolvencniPravo;

    public override string ToString()
    {
        return $"Jméno: {Jmeno}, Příjmení: {Prijmeni}, Adresa: {Adresa}, Specializace: {Specializace.ZiskejPopis()}";
    }
}

