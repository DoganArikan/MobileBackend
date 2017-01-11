using MobileBackend.Models;
using MobileBackend.Models.InitialObjects;
using MobileBackend.Models.ResultObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileBackend.Core;
namespace MobileBackend.Controllers
{
    public class MesajController : ApiController
    {
       public static string msj="";
       [HttpPost]
       [Authorize]

        public MesajGetirResultParameter MesajGetir([FromBody] MesajGetirInitParameter mesajGetirInitParameter)
       {
           try
           {

               DataTable dt = PR_MESAJ_GETIR(mesajGetirInitParameter);
               if (dt.Rows.Count == 0)
               {

                   return new MesajGetirResultParameter() { Sonuc = new Sonuc { SonucKod = -1, SonucMesaj = "Mesaj Bilgisi Bulunamadı", Ekran = 1 } };
               }
               List<mesaj> mesajList = new List<mesaj>();
               foreach (DataRow dataRow in dt.Rows)
               {
                   mesaj mesaj = new mesaj();
                   mesaj.ALICI_SICIL_KOD = Converter.ToInt32(dataRow["ALICI_SICIL_KOD"]);
                   mesaj.EKLENEN_TARIH = Converter.ToDateTime(dataRow["EKLENEN_TARIH"]);
                   mesaj.GONDEREN_SICIL_KOD = Converter.ToInt32(dataRow["GONDEREN_SICIL_KOD"]);
                   mesaj.ID = Converter.ToInt32(dataRow["ID"]);
                   mesaj.MESAJ_ID =  Converter.ToInt32(dataRow["MESAJ_ID"]);
                   mesaj.MESAJ1 = dataRow["MESAJ"].ToString();
                   mesajList.Add(mesaj);
               }
               return new MesajGetirResultParameter() { Mesaj = mesajList.ToArray(), Sonuc = new Sonuc { SonucKod = 0, SonucMesaj = "Mesaj Bulundu", Ekran = 0 } };
           }
           catch(Exception ex)
           {
               return new MesajGetirResultParameter() { Sonuc = new Sonuc { ExceptionStackTrace = ex.StackTrace, SonucKod = -1, SonucMesaj = "Mesaj Bilgisi Bulunamadı", Ekran = 1 } };
           }
           finally
           {
           }


       }

       [HttpPost]
       [Authorize]

       public MesajGonderResultParameter MesajGonder([FromBody] MesajGonderInitParameter mesajGonderInitParameter)
       {
           int ID;
           try
           {
               var db = new hbtrinsi_insideEntities();

               var t = new mesaj
               {
                   ALICI_SICIL_KOD = mesajGonderInitParameter.AliciSicilKod,
               //    EKLENEN_TARIH = DateTime.Now,
                   GONDEREN_SICIL_KOD = mesajGonderInitParameter.GonderenSicilKod,
                   MESAJ1 = mesajGonderInitParameter.Mesaj
               };

               db.mesaj.Add(t);
               db.SaveChanges();
               ID = t.ID;

               var t1 = new mesaj_organizasyon
               {
                   MESAJ_ID = t.ID,
                   ORG_NO = mesajGonderInitParameter.OrgNo 
               };

               db.mesaj_organizasyon.Add(t1);
               db.SaveChanges();

               return new MesajGonderResultParameter() { MesajId = ID, Sonuc = new Sonuc { SonucKod = 0, SonucMesaj = "Mesaj Bilgisi Gönderildi", Ekran = 1 }, RMesajGonderInitParameter = mesajGonderInitParameter };
              
           }
           catch(Exception ex)
           {
               msj = ex.StackTrace;
               return new MesajGonderResultParameter() { Sonuc = new Sonuc { ExceptionStackTrace = ex.StackTrace, SonucKod = -1, SonucMesaj = "Mesaj Bilgisi Gönderilemedi", Ekran = 1 }, RMesajGonderInitParameter = mesajGonderInitParameter };
           }
           finally
           {
           }


       }

       public List<decimal> GetTumOrganizasyon( decimal parentOrganizasyon)
       {
           using (hbtrinsi_insideEntities context = new hbtrinsi_insideEntities())
           {
               System.Data.Entity.DbSet<gen_organizasyon> OrganizasyonBilgileri = context.gen_organizasyon;
               var query = OrganizasyonBilgileri.Where(x => x.PARENT_ORG_NO == parentOrganizasyon);
               List<decimal> ListOrganizasyonBilgileri = new List<decimal>();

               foreach (gen_organizasyon emp in query.ToList())
                   ListOrganizasyonBilgileri.Concat( GetTumOrganizasyon( emp.ORG_NO));

               return ListOrganizasyonBilgileri;
           }
       }
       private static string GetConnectionString()
       {
           return ConfigurationManager.ConnectionStrings["HB_Inside"].ConnectionString;
       }
       private static DataTable PR_MESAJ_GETIR(MesajGetirInitParameter mesajGetirInitParameter)
       {
           DataTable Dt = new DataTable("PR_MESAJ_GETIR");
           try
           {

               MySqlCommand cmd = new MySqlCommand("PR_MESAJ_GETIR", new MySqlConnection(GetConnectionString())); ;

               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("P_MESAJ_ID", mesajGetirInitParameter.MesajId);
               cmd.Parameters.AddWithValue("P_MESAJ_GUNCELLEME_YON", mesajGetirInitParameter.MesajGuncellemeYon);
               cmd.Parameters.AddWithValue("P_SICIL_KOD", mesajGetirInitParameter.SicilKod);
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

    }
}
