using MobileBackend.Models.InitialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.Models.ResultObjects
{
    public class MesajGonderResultParameter
    {
        public int MesajId { get; set; }
        public Sonuc Sonuc { get; set; }
        public MesajGonderInitParameter RMesajGonderInitParameter { get; set; }

    }
}