using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.Models.InitialObjects
{
    public class MesajGonderInitParameter
    {
        public int GonderenSicilKod { get; set; }
        public string Mesaj { get; set; }
        public decimal OrgNo { get; set; }
        public Nullable<int> AliciSicilKod { get; set; }
    }
}