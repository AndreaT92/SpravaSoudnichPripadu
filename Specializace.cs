using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public enum Specializace
    {
        [Description("Civilní právo")]
        CivilniPravo,

        [Description("Trestní právo")]
        TrestniPravo,

        [Description("Insolvenční právo")]
        InsolvencniPravo,
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
