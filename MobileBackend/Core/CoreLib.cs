using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;

namespace MobileBackend.Core
{
    public static class CoreLib
    {
        /// <summary>
        /// Obje serialize edilebilir mi? kontrolunu yapar
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsSerializable(this object o)
        {
            if (o is ISerializable)
                return true;
            if (o.GetType().Name == "Byte[]")
                return true;
            return Attribute.IsDefined(o.GetType(), typeof(SerializableAttribute));
        }

        /// <summary>
        /// Obje null degerli mi? kontrolu yapar
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool Assigned(this object o)
        {
            if (o is string)
                return !string.IsNullOrEmpty((string)o);

            if (o is DateTime)
                return (DateTime)o > DateTime.MinValue;

            return (o != null);
        }

        /// <summary>
        /// Obje null degerli degil mi? kontrolu yapar
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool NotAssigned(this object o)
        {
            return !Assigned(o);
        }

        /// <summary>
        /// Sifir degerini null yapar
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static object ZeroToNull(this object o)
        {
            if (!Assigned(o))
            {
                return null;
            }
            else
            {
                return String.Equals(Converter.ToString(o),"0") ? null : o;
            }
        }

        /// <summary>
        /// DataTable List donusumunu yapar
        /// </summary>
        /// <param name="table"></param>
        /// <returns>List<Hashtable></returns>
        public static List<Hashtable> DataTableToList(DataTable table)
        {
            List<Hashtable> list = new List<Hashtable>();
            if (table.NotAssigned())
                return list;
            foreach (DataRow row in table.Rows)
            {
                Hashtable ht = new Hashtable();
                foreach (DataColumn col in table.Columns)
                {
                    ht.Add(col.ColumnName,row[col]);
                }
                list.Add(ht);
            }
            return list;
        }
        
        /// <summary>
        /// DataTable JSON donusumunu yapar
        /// </summary>
        /// <param name="table"></param>
        /// <returns>JSON String</returns>
        public static string DataTableToJson(DataTable table)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(DataTableToList(table));
        }
    }
}
