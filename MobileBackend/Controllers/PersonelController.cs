using MobileBackend.Core;
using MobileBackend.Models;
using MobileBackend.Models.InitialObjects;
using MobileBackend.Models.ResultObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Http;


namespace MobileBackend.Controllers
{
    public class PersonelController : ApiController
    {
        public static string msj;


        [HttpPost]
        [Authorize]

        public PersonelBilgisiGetirResultParameter PersonelBilgisiGetir([FromBody] PersonelBilgisiGetirInitParameter personelBilgisiGetirInitParameter)
        {
            //List<gen_personel> result;

            try
            {

                //   using (hbtrinsi_insideEntities context = new hbtrinsi_insideEntities())
                //{
                //System.Data.Entity.DbSet<gen_personel> PersonelBilgileri = context.gen_personel;

                //var query= PersonelBilgileri
                //    .Where(x => x.SICIL_KOD == personelBilgisiGetirInitParameter.SicilKod );

                var db = new hbtrinsi_insideEntities();
              
                DataTable dt = PR_TELEFON_NO_KONTROL(personelBilgisiGetirInitParameter.TelNo, personelBilgisiGetirInitParameter.SicilKod);
                if (dt.Rows.Count == 0)
                {

                    return new PersonelBilgisiGetirResultParameter() { Sonuc = new Sonuc { SonucKod = -1, SonucMesaj = "Personel Bilgisi Bulunamadı", Ekran = 1 } };
                }
                List<gen_personel> personelList = new List<gen_personel>();
                foreach (DataRow dataRow in dt.Rows)
                {    
                    gen_personel genpersonel = new gen_personel();
                    genpersonel.AD                    = dataRow["AD"].ToString();  
                    genpersonel.SOYAD                 = dataRow["SOYAD"].ToString();  
                    genpersonel.SIFRE                 = dataRow["SIFRE"].ToString();  
                    genpersonel.ULKE_KOD              = dataRow["ULKE_KOD"].ToString();  
                    genpersonel.ORG_NO                = Converter.ToInt32(dataRow["ORG_NO"]); 
                    genpersonel.SW_BORDRO_ALT_BIRIM   = Converter.ToInt32(dataRow["SW_BORDRO_ALT_BIRIM"]); 
                    genpersonel.POZISYON              = dataRow["POZISYON"].ToString();  
                    genpersonel.CINSIYET              = dataRow["CINSIYET"].ToString();  
                    genpersonel.DOGUM_TARIHI          = Converter.ToDateTime(dataRow["DOGUM_TARIHI"]);
                    genpersonel.MEDENI_DURUM          = dataRow["MEDENI_DURUM"].ToString();  
                    genpersonel.KAN_GRUBU             = dataRow["KAN_GRUBU"].ToString();  
                    genpersonel.ISE_GIRIS_TARIHI      = Converter.ToDateTime(dataRow["ISE_GIRIS_TARIHI"]);
                    genpersonel.ISTEN_CIKIS_TARIHI    = Converter.ToDateTime(dataRow["ISTEN_CIKIS_TARIHI"]);  
                    genpersonel.SIRKET_NO             = Converter.ToInt32(dataRow["SIRKET_NO"]);  
                    genpersonel.TC_KIMLIK_NO          = dataRow["TC_KIMLIK_NO"].ToString();  
                    genpersonel.SSK_NO                = dataRow["SSK_NO"].ToString();  
                    genpersonel.ADRES                 = dataRow["ADRES"].ToString();  
                    genpersonel.IL                    = dataRow["IL"].ToString();  
                    genpersonel.ILCE                  = dataRow["ILCE"].ToString();  
                    genpersonel.TEL1                  = dataRow["TEL1"].ToString();  
                    genpersonel.TEL2                  = dataRow["TEL2"].ToString();  
                    genpersonel.EMAIL                 = dataRow["EMAIL"].ToString();  
                    genpersonel.EGITIM                = dataRow["EGITIM"].ToString();  
                    genpersonel.MUHASEBE_KODU         = Converter.ToInt32(dataRow["MUHASEBE_KODU"]);    
                    genpersonel.SW_USTALIK            = Converter.ToInt32(dataRow["SW_USTALIK"]);    
                    genpersonel.NAR_HESABI_GRUBU      = dataRow["NAR_HESABI_GRUBU"].ToString();  
                    genpersonel.SW_MERKEZ_URETIM      = Converter.ToInt32(dataRow["SW_MERKEZ_URETIM"]);    
                    genpersonel.POSTA_KOD             = Converter.ToInt32(dataRow["POSTA_KOD"]);    
                    genpersonel.SICIL_KAYNAK          = dataRow["SICIL_KAYNAK"].ToString();  
                    genpersonel.YONETICI_1            = dataRow["YONETICI_1"].ToString();  
                    genpersonel.YONETICI_2            = dataRow["YONETICI_2"].ToString();  
                    genpersonel.YONETICI_3            = dataRow["YONETICI_3"].ToString();  
                    genpersonel.SORUMLU_ORG_1         = Converter.ToInt32(dataRow["SORUMLU_ORG_1"]);    
                    genpersonel.SORUMLU_ORG_2         = Converter.ToInt32(dataRow["SORUMLU_ORG_2"]);  
                    genpersonel.SORUMLU_ORG_3         = Converter.ToInt32(dataRow["SORUMLU_ORG_3"]);  
                    genpersonel.CALISMA_GRUBU         = dataRow["CALISMA_GRUBU"].ToString();
                    genpersonel.EKLEYEN_KULLANICI     = Converter.ToInt32(dataRow["EKLEYEN_KULLANICI"]);  
                    genpersonel.EKLENEN_TARIH         = Converter.ToDateTime(dataRow["EKLENEN_TARIH"]); 
                    genpersonel.GUNCELLEYEN_KULLANICI = Converter.ToInt32(dataRow["GUNCELLEYEN_KULLANICI"]);  
                    genpersonel.GUNCELLENEN_TARIH     = Converter.ToDateTime(dataRow["GUNCELLENEN_TARIH"]);
                    genpersonel.SW_AKTIF              = Converter.ToInt32(dataRow["SW_AKTIF"]);  
                    genpersonel.POZISYON_ACIKLAMA     = dataRow["POZISYON_ACIKLAMA"].ToString();
                    genpersonel.SAP_ORG_KOD           = Converter.ToInt32(dataRow["SAP_ORG_KOD"]);  
                    genpersonel.SAP_ORG_ACIKLAMA      = dataRow["SAP_ORG_ACIKLAMA"].ToString();
                    genpersonel.BMS_FABRIKA_KOD       = Converter.ToInt32(dataRow["BMS_FABRIKA_KOD"]);  
                    genpersonel.BMS_URUN_GRUP_KOD     = Converter.ToInt32(dataRow["BMS_URUN_GRUP_KOD"]);  
                    genpersonel.BMS_HAT_KOD           = Converter.ToInt32(dataRow["BMS_HAT_KOD"]);  
                    genpersonel.BMS_GRUP_KOD          = Converter.ToInt32(dataRow["BMS_GRUP_KOD"]);  
                    genpersonel.BMS_EKIP_KOD          = Converter.ToInt32(dataRow["BMS_EKIP_KOD"]);  
                    genpersonel.BMS_DEPARTMAN_KOD     = Converter.ToInt32(dataRow["BMS_DEPARTMAN_KOD"]);  
                    personelList.Add(genpersonel);
                }
                return new PersonelBilgisiGetirResultParameter() { Bilgi = personelList.ToArray(), Sonuc = new Sonuc { SonucKod = 0, SonucMesaj = "Personel Bulundu", Ekran = 0 } };
            }
            catch (Exception ex)
            {
                return new PersonelBilgisiGetirResultParameter() { Sonuc = new Sonuc { ExceptionStackTrace = ex.StackTrace, SonucKod = -1, SonucMesaj = "Personel Bilgisi Bulunamadı", Ekran = 1 } };
            }
            finally
            {
            }

        }

        public static DataTable PR_TELEFON_NO_KONTROL(String P_TEL_NO, Decimal P_SICIL_KOD)
        {
            DataTable Dt = new DataTable("PR_TELEFON_NO_KONTROL");
            try
            {

                MySqlCommand cmd = new MySqlCommand("PR_TELEFON_NO_KONTROL", new MySqlConnection(GetConnectionString())); ;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("P_TEL_NO", P_TEL_NO);
                cmd.Parameters.AddWithValue("P_SICIL_KOD", P_SICIL_KOD);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(Dt);

                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                msj = ex.ToString();
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                //if (cmd.Connection != null) 
                //        cmd.Connection.Close();
            }
            return Dt;
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HB_Inside"].ConnectionString;
        }
        public static string CleanPhone(string phone)
        {
            if (phone == null)
            { return null; }
            {
                Regex digitsOnly = new Regex(@"[^\d]");
                string str = digitsOnly.Replace(phone, "");
                return str.Substring(str.Length - 10);
            }
        }


    }
}