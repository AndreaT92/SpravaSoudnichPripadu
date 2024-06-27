using SpravaSoudnichPripadu.osoby;
using System.Text;

namespace SpravaSoudnichPripadu
{
    public class Pripad
    {
        // třída pro základní properties případu
        // propojit nějak se správou případů ? logikou filtrování?
        

        public bool JeSkonceno;
        public int CisloPripadu { get; set; }
        public string? Popis { get; set; }
        public List<Ucastnik> Ucastnici { get; set; }
        public List<Soudce> Soudci { get; set; }
        public List<Zastupce> Zastupci { get; set; }
        public DateTime DatumJednani { get; set; }

        public Pripad()
        {
            Ucastnici = new List<Ucastnik>();
            Zastupci = new List<Zastupce>();
            Soudci = new List<Soudce>();

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Případ {CisloPripadu+1}: {Popis}");
            sb.AppendLine($"Datum jednání: {DatumJednani}, Skončeno: {JeSkonceno}");
            sb.AppendLine("Soudci:");
            foreach (var soudce in Soudci)
            {
                sb.AppendLine($"- {soudce}");
            }
            sb.AppendLine("Účastníci řízení:");
            foreach (var ucastnik in Ucastnici)
            {
                sb.AppendLine($"- {ucastnik}, Role: {ucastnik.roleVRizeni}");
            }
            sb.AppendLine("Zástupci:");
            foreach (var zastupce in Zastupci)
            {
                sb.AppendLine($"- {zastupce}");
            }
            return sb.ToString();
        }


    }
}
