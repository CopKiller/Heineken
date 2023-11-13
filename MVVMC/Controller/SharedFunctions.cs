using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVMC.Controller
{
    public enum CraftProducts
    {
        [Description("baddenlogo.png")]
        Badden,
        [Description("bluemoonlogo.png")]
        Bluemoon,
        [Description("lagunitaslogo.png")]
        Lagunitas
    }

    public enum PremiumProducts
    {
        Heineken,
        Heineken00,
    }
    public enum MainStreamProducts
    {
        Amstel,
        Devassa
    }
    public enum PagesSovi
    {
        Craft,
        Premium,
        MainStream
    }

    public static class GetValues
    {
        public static string GetEnumName(Enum value)
        {
            return Enum.GetName(value.GetType(), value);
        }
        public static string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null)
            {
                return null;
            }

            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
