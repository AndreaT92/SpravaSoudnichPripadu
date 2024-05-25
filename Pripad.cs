namespace SpravaSoudnichPripadu
{
    public class Pripad
    {
        // třída pro základní properties případu
        // propojit nějak se správou případů ? logikou filtrování?
        

        public bool JeSkonceno;

        public bool SopZaplacen;

        public bool JeOdmenaZaplacena;
        public int CisloPripadu { get; set; }
        public string Popis { get; set; }
        public List<Ucastnik> Ucastnici { get; set; }
        public Soudce Soudci { get; set; }
        public List<Zastupce> Zastupci { get; set; }
        public DateTime DatumJednani { get; set; }

        public Pripad()
        {
            Ucastnici = new List<Ucastnik>();
            Zastupci = new List<Zastupce>();
        }


    }
}
