namespace SpravaSoudnichPripadu.osoby
{
    /// <summary>
    /// odvozená třída pro zástupce
    /// </summary>
    public class Zastupce : Osoba
    {

        /// <summary>
        /// Cak znamena identifikační číslo advokáta
        /// </summary>

        public int cak { get; set; }

        public RoleVRizeniZastupce RoleVRizeniZastupce { get; set; }
        //public int unikatniCislo { get; set; } //pro rychlejsi filtrovani?

        public bool JeRoleVRizeniZastZalobce => RoleVRizeniZastupce == RoleVRizeniZastupce.ZástupceŽalobce;
        public bool JeRoleVRizeniZastZalovaneho => RoleVRizeniZastupce == RoleVRizeniZastupce.ZástupceŽalovaného;

    }
}
