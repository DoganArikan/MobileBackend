using MobileBackend.Models.InitialObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileBackend.Models.ResultObjects
{
    public class MesajGetirResultParameter
    {
        public mesaj[] Bilgi { get; set; }
        public Sonuc Sonuc { get; set; }
    }
}