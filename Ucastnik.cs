namespace SpravaSoudnichPripadu
{
    public class Ucastnik : Osoba
    {
        //odvozená třída pro účastníky řízení
        public string roleVRizeni { get; set; }
        public int unikatniCislo { get; set; } //pro rychlejsi filtrovani?

    }
}
