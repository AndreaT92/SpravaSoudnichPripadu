namespace SpravaSoudnichPripadu.osoby
{
    //odvozená třída pro účastníky řízení
    public class Ucastnik : Osoba
    {

        public RoleVRizeni roleVRizeni { get; set; }
        
        public bool JeRoleVRizeniZalobce => roleVRizeni == RoleVRizeni.Žalobce;
        public bool JeRoleVRizeniZalovany => roleVRizeni == RoleVRizeni.Žalovaný;


    }
}

