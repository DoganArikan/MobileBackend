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
    
    public partial class gen_organizasyon
    {
        public gen_organizasyon()
        {
            this.gen_personel = new HashSet<gen_personel>();
            this.gen_personel1 = new HashSet<gen_personel>();
            this.gen_personel2 = new HashSet<gen_personel>();
            this.gen_personel3 = new HashSet<gen_personel>();
            this.gen_personel4 = new HashSet<gen_personel>();
            this.gen_personel5 = new HashSet<gen_personel>();
            this.gen_personel6 = new HashSet<gen_personel>();
            this.gen_personel7 = new HashSet<gen_personel>();
            this.gen_personel8 = new HashSet<gen_personel>();
            this.gen_personel9 = new HashSet<gen_personel>();
            this.mesaj = new HashSet<mesaj>();
        }
    
        public decimal ORG_NO { get; set; }
        public string ORG_AD { get; set; }
        public string ORG_AD_EN { get; set; }
        public decimal ORG_TIP_NO { get; set; }
        public Nullable<decimal> PARENT_ORG_NO { get; set; }
        public Nullable<decimal> MALIYET_MERKEZ_KOD { get; set; }
        public string MALIYET_MERKEZ_AD { get; set; }
        public Nullable<decimal> FABRIKA_ORG_NO { get; set; }
        public Nullable<decimal> HAT_ORG_NO { get; set; }
        public Nullable<decimal> GRUP_ORG_NO { get; set; }
        public string URETIM_KOD { get; set; }
        public decimal SW_GUNLUK_HESAPLAMA { get; set; }
        public Nullable<decimal> KARIYER_BASAMAK_1 { get; set; }
        public Nullable<decimal> KARIYER_BASAMAK_2 { get; set; }
        public Nullable<decimal> KARIYER_BASAMAK_3 { get; set; }
        public string ORG_DURUM { get; set; }
        public decimal EKLEYEN_KULLANICI { get; set; }
        public System.DateTime EKLENEN_TARIH { get; set; }
        public Nullable<decimal> GUNCELLEYEN_KULLANICI { get; set; }
        public Nullable<System.DateTime> GUNCELLENEN_TARIH { get; set; }
        public string ULKE_KOD { get; set; }
        public decimal SW_MAKINE_TRANSFER_YAPILABILIR { get; set; }
        public string UST_HAT_KOD { get; set; }
        public string HAT_TIP { get; set; }
        public Nullable<decimal> DAGITIMSURE { get; set; }
        public string ORG_KISA_AD { get; set; }
        public string FAALIYET_RUHSAT_NO { get; set; }
        public Nullable<decimal> SW_KESIM_EKIP { get; set; }
    
        public virtual ICollection<gen_personel> gen_personel { get; set; }
        public virtual ICollection<gen_personel> gen_personel1 { get; set; }
        public virtual ICollection<gen_personel> gen_personel2 { get; set; }
        public virtual ICollection<gen_personel> gen_personel3 { get; set; }
        public virtual ICollection<gen_personel> gen_personel4 { get; set; }
        public virtual ICollection<gen_personel> gen_personel5 { get; set; }
        public virtual ICollection<gen_personel> gen_personel6 { get; set; }
        public virtual ICollection<gen_personel> gen_personel7 { get; set; }
        public virtual ICollection<gen_personel> gen_personel8 { get; set; }
        public virtual ICollection<gen_personel> gen_personel9 { get; set; }
        public virtual ICollection<mesaj> mesaj { get; set; }
    }
}