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
    
    public partial class personel_tur
    {
        public personel_tur()
        {
            this.gen_personel = new HashSet<gen_personel>();
        }
    
        public int ID { get; set; }
        public string ACIKLAMA { get; set; }
    
        public virtual ICollection<gen_personel> gen_personel { get; set; }
    }
}
