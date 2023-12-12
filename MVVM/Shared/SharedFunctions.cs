
using System.ComponentModel;

namespace AplicativoPromotor.MVVM.Shared
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
        [Description("heinekenlogo.png")]
        Heineken,
        [Description("heineken00logo.png")]
        Heineken00,
        [Description("eisenbahnlogo.png")]
        Eisenbahn,
        [Description("sollogo.png")]
        Sol
    }
    public enum MainStreamProducts
    {
        [Description("amstellogo.png")]
        Amstel,
        [Description("devassalogo.png")]
        Devassa
    }
    public enum PagesSovi
    {
        Config,
        Craft,
        Premium,
        MainStream,
        Resumo
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
