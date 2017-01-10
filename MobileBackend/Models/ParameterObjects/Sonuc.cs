using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.Models.InitialObjects
{
    public class Sonuc
    {
        public decimal SonucKod { get; set; }
        public string SonucMesaj { get; set; }
        public decimal Ekran { get; set; }
        public string ExceptionStackTrace { get; set; }
    }
}