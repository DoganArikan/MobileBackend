//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileBackend
{
    using System;
    using System.Collections.Generic;
    
    public partial class mesaj
    {
        public mesaj()
        {
            this.gen_organizasyon = new HashSet<gen_organizasyon>();
        }
    
        public int ID { get; set; }
        public int SICIL_KOD { get; set; }
        public string MESAJ1 { get; set; }
        public System.DateTime EKLENEN_TARIH { get; set; }
        public string BARER_TOKEN { get; set; }
    
        public virtual gen_personel gen_personel { get; set; }
        public virtual ICollection<gen_organizasyon> gen_organizasyon { get; set; }
    }
}