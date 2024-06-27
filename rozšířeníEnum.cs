using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpravaSoudnichPripadu
{
    public static class rozšířeníEnum
    {
       
            public static string ZiskejPopis(this Enum value)
            {
                var fieldInfo = value.GetType().GetField(value.ToString());
                var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : value.ToString();
            }
        }
    }

