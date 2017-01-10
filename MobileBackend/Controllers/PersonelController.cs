using MobileBackend.Models;
using MobileBackend.Models.InitialObjects;
using MobileBackend.Models.ResultObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace MobileBackend.Controllers
{
    public class PersonelController : ApiController
    {



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
                List<gen_personel> result;

                var query = db.gen_personel.Where(x => x.SICIL_KOD == 76868//personelBilgisiGetirInitParameter.SicilKod
                    ).AsEnumerable();
                result = query.ToList();
               
                if (query.ToList().Count == 0)
                {

                    return new PersonelBilgisiGetirResultParameter() { Sonuc = new Sonuc { SonucKod = -1, SonucMesaj = "Personel Bilgisi Bulunamadı", Ekran = 1 } };
                }
                else
                {

                    result = query.ToList();
                }
             //}
                return new PersonelBilgisiGetirResultParameter() { PersonelBilgi = result.ToArray(),Sonuc =new Sonuc{SonucKod = 0 , SonucMesaj ="Personel Bulundu",Ekran = 0}};
            
            }
            catch(Exception ex)
            {
                return new PersonelBilgisiGetirResultParameter() { Sonuc = new Sonuc { ExceptionStackTrace = ex.StackTrace, SonucKod = -1, SonucMesaj = "Personel Bilgisi Bulunamadı", Ekran = 1 } };
            }
            finally
            {

            }
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Order> G()
        {
            return null;
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetOrder(int id)
        {

            return null;

        }

    }
}