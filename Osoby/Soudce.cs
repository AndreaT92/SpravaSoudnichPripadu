namespace SpravaSoudnichPripadu.osoby
{
    // odvozená třída pro soudce 
    public class Soudce : Osoba
    {
         public Specializace Specializace { get; set; }
        //public int unikatniCislo { get; set; } //pro rychlejsi filtrovani?

        public bool JeCivil=> Specializace == Specializace.CivilníPrávo;
        public bool JeTrest => Specializace == Specializace.TrestníPrávo;
        public bool JeInsko => Specializace == Specializace.InsolvenčníPrávo;
    }
}
