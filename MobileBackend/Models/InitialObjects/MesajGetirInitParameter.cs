using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.Models.InitialObjects
{
    public class MesajGetirInitParameter
    {
        public decimal MesajId { get; set; }
        //1 Pozitif 10 tane // -1 Negatif 10 tane
        public decimal MesajGuncellemeYon { get; set; }
        public decimal SicilKod { get; set; }

    }
}