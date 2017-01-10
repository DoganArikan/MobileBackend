using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MobileBackend.Core
{
    public static class Converter
    {

        public static String ToString(object value)
        {
            String retVal = null;
            try
            {
                retVal = value.ToString();
            }
            catch { }
            return retVal;
        }

        public static String ToString(DateTime? value, string format)
        {
            String retVal = null;
            try
            {
                DateTime date = Convert.ToDateTime(value);
                retVal = date == DateTime.MinValue ? null : date.ToString(format, CultureInfo.InvariantCulture);
            }
            catch { }
            return retVal;
        }

        public static DateTime? ToNullDateTime(string value, string format)
        {
            DateTime? retVal = null;
            try
            {
                DateTime date = Converter.ToDateTime(value, format);
                retVal = date == DateTime.MinValue ? null : (DateTime?)date;
            }
            catch { }
            return retVal;
        }

        public static DateTime? ToNullDateTime(object value)
        {
            DateTime? retVal = null;
            try
            {
                DateTime date = Convert.ToDateTime(value);
                retVal = date == DateTime.MinValue ? null : (DateTime?)date;
            }
            catch { }
            return retVal;
        }

        public static Decimal? ToNullDecimal(object value)
        {
            Decimal? retVal = null;
            try
            {
                if (value == null)
                    retVal = null;
                else
                    retVal = Convert.ToDecimal(value);
            }
            catch { }
            return retVal;
        }

        public static Double? ToNullDouble(object value)
        {
            Double? retVal = null;
            try
            {
                if (value == null)
                    retVal = null;
                else
                    retVal = Convert.ToDouble(value);
            }
            catch { }
            return retVal;
        }

        public static Int32? ToNullInt32(object value)
        {
            Int32? retVal = null;
            try
            {
                if (value == null)
                    retVal = null;
                else
                    retVal = Convert.ToInt32(value);
            }
            catch { }
            return retVal;
        }

        public static DateTime ToDateTime(string value, string format)
        {
            DateTime retVal = DateTime.MinValue;
            try
            {
                DateTime date;
                if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    retVal = date;
                }
            }
            catch { }
            return retVal;
        }

        public static DateTime ToDateTime(object value)
        {
            DateTime retVal = DateTime.MinValue;
            try
            {
                retVal = Convert.ToDateTime(value);
            }
            catch { }
            return retVal;
        }

        public static Decimal ToDecimal(object value, decimal defaultValue)
        {
            decimal retVal = defaultValue;
            if (value.Assigned())
            {
                Decimal.TryParse(Convert.ToString(value), out retVal);
            }
            //try
            //{
            //    retVal = Convert.ToDecimal(value);
            //}
            //catch { }
            return retVal;
        }

        public static Decimal ToDecimal(object value)
        {
            return ToDecimal(value, 0);
        }

        public static Double ToDouble(object value, double defaultValue)
        {
            double retVal = defaultValue;
            if (value.Assigned())
            {
                Double.TryParse(Convert.ToString(value), out retVal);
            }
            return retVal;
        }

        public static Double ToDouble(object value)
        {
            return ToDouble(value, 0);
        }

        public static Int32 ToInt32(object value, Int32 defaultValue)
        {
            Int32 retVal = defaultValue;
            if (value.Assigned())
            {
                Int32.TryParse(Convert.ToString(value), out retVal);
            }
            //try
            //{
            //    retVal = Convert.ToInt32(value);
            //}
            //catch { }
            return retVal;
        }

        public static Int32 ToInt32(object value)
        {
            return ToInt32(value, 0);
        }

        public static Int64 ToInt64(object value, Int64 defaultValue)
        {
            Int64 retVal = defaultValue;
            if (value.Assigned())
            {
                Int64.TryParse(Convert.ToString(value), out retVal);
            }
            //try
            //{
            //    retVal = Convert.ToInt64(value);
            //}
            //catch { }
            return retVal;
        }

        public static Int64 ToInt64(object value)
        {
            return ToInt64(value, 0);
        }

        public static Boolean ToBoolean(object value, Boolean defaultValue)
        {
            Boolean retVal = defaultValue;
            if (value.Assigned())
            {
                Boolean.TryParse(Convert.ToString(value), out retVal);
            }
            //try
            //{
            //    retVal = Convert.ToBoolean(value);
            //}
            //catch { }
            return retVal;
        }

        public static Boolean ToBoolean(object value)
        {
            return ToBoolean(value, false);
        }

        public static String ToShortDateString(object value)
        {
            DateTime date = ToDateTime(value);
            if (date != DateTime.MinValue)
            {
                return date.ToString("dd.MM.yyyy");
            }
            else
            {
                return string.Empty;
            }
        }

        public static String ToCurrencyString(object value)
        {
            decimal retVal = ToDecimal(value);
            return retVal.ToString("#,##0.00");
        }

        public static String ToAmountString(decimal value)
        {
            string sTutar = value.ToString("F2").Replace('.', ',');
            string lira = sTutar.Substring(0, sTutar.IndexOf(','));
            string kurus = sTutar.Substring(sTutar.IndexOf(',') + 1, 2);
            string yazi = "";

            string[] birler = { "", "BİR", "İKİ", "ÜÇ", "DÖRT", "BEŞ", "ALTI", "YEDİ", "SEKİZ", "DOKUZ" };
            string[] onlar = { "", "ON", "YİRMİ", "OTUZ", "KIRK", "ELLİ", "ALTMIŞ", "YETMİŞ", "SEKSEN", "DOKSAN" };
            string[] binler = { "KATRİLYON", "TRİLYON", "MİLYAR", "MİLYON", "BİN", "" };

            int grupSayisi = 6; //sayıdaki 3'lü grup sayısı. katrilyon için 6. (1.234,00 daki grup sayısı 2'dir.)
            //KATRİLYON'un başına ekleyeceğiniz her değer için grup sayısını artırınız.

            lira = lira.PadLeft(grupSayisi * 3, '0'); //sayının soluna '0' eklenerek sayı 'grup sayısı x 3' basamaklı yapılıyor.            

            string grupDegeri;

            for (int i = 0; i < grupSayisi * 3; i += 3) //sayı 3'erli gruplar halinde ele alınıyor.
            {
                grupDegeri = "";

                if (lira.Substring(i, 1) != "0")
                    grupDegeri += birler[Convert.ToInt32(lira.Substring(i, 1))] + "YÜZ";

                if (grupDegeri == "BİRYÜZ")
                    grupDegeri = "YÜZ";

                grupDegeri += onlar[Convert.ToInt32(lira.Substring(i + 1, 1))];

                grupDegeri += birler[Convert.ToInt32(lira.Substring(i + 2, 1))];

                if (grupDegeri != "")
                    grupDegeri += binler[i / 3];

                if (grupDegeri == "BİRBİN")
                    grupDegeri = "BİN";

                yazi += grupDegeri;
            }

            if (yazi != "")
                yazi += " TL ";

            int yaziUzunlugu = yazi.Length;

            if (kurus.Substring(0, 1) != "0")
                yazi += onlar[Convert.ToInt32(kurus.Substring(0, 1))];

            if (kurus.Substring(1, 1) != "0")
                yazi += birler[Convert.ToInt32(kurus.Substring(1, 1))];

            if (yazi.Length > yaziUzunlugu)
                yazi += " Kr.";

            return yazi;
        }

        public static object ChangeType(object value, PropertyInfo pi)
        {
            if (value.Assigned())
            {
                Type u = Nullable.GetUnderlyingType(pi.PropertyType);
                try
                {
                    if (u != null)
                    {
                        if (u.IsEnum)
                        {
                            int enumVal = Converter.ToInt32(value);
                            if (enumVal > 0)
                                return Enum.ToObject(u, enumVal);
                            else
                                return Enum.Parse(u, Converter.ToString(value));
                        }
                        else
                        {
                            return Convert.ChangeType((object)value, u);
                        }
                    }
                    else
                    {
                        if (pi.PropertyType.IsEnum)
                        {
                            int enumVal = Converter.ToInt32(value);
                            if(enumVal > 0)
                                return Enum.ToObject(pi.PropertyType, enumVal);
                            else
                                return Enum.Parse(pi.PropertyType, Converter.ToString(value));
                        }
                        else
                        {
                            return Convert.ChangeType((object)value, pi.PropertyType);
                        }
                    }
                }
                catch { }
            }
            return null;
        }

    }
}
