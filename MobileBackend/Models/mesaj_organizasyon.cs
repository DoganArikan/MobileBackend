//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileBackend.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class mesaj_organizasyon
    {
        public int ID { get; set; }
        public decimal ORG_NO { get; set; }
        public int MESAJ_ID { get; set; }
    
        public virtual gen_organizasyon gen_organizasyon { get; set; }
        public virtual mesaj mesaj { get; set; }
    }
}
