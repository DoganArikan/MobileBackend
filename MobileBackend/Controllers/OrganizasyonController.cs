
using MobileBackend.Models;
using MobileBackend.Models.InitialObjects;
using MobileBackend.Models.ResultObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MobileBackend.Controllers
{
    public class OrganizasyonController : ApiController
    {
        [HttpPost]
        [Authorize]

        public OrganizasyonBilgisiGetirResultParameter OrganizasyonAgaciBilgisiGetir([FromBody] OrganizasyonBilgisiGetirInitParameter OrganizasyonBilgisiGetirInitParameter)
        {
            try
            {
                
                using (hbtrinsi_insideEntities context = new hbtrinsi_insideEntities())
                {
                    System.Data.Entity.DbSet<gen_organizasyon> OrganizasyonBilgileri = context.gen_organizasyon;
                    var query = OrganizasyonBilgileri.Where(x => x.PARENT_ORG_NO == OrganizasyonBilgisiGetirInitParameter.OrgNo);

                    if (query.ToList().Count == 0)
                    {

                        return new OrganizasyonBilgisiGetirResultParameter() { Sonuc = new Sonuc { SonucKod = -1, SonucMesaj = "Organizasyon Bilgisi Bulunamadı", Ekran = 1 } };
                    }
                    return new OrganizasyonBilgisiGetirResultParameter() { Bilgi = (query.ToList()).ToArray(), Sonuc = new Sonuc { SonucKod = 0, SonucMesaj = "Organizasyon Bulundu", Ekran = 0 } };
                }
            }
            catch (Exception ex)
            {
                return new OrganizasyonBilgisiGetirResultParameter() { Sonuc = new Sonuc { ExceptionStackTrace = ex.StackTrace, SonucKod = -1, SonucMesaj = "Organizasyon Bilgisi Bulunamadı", Ekran = 1 } };
            }
            finally
            {

            }
        }

    
    }

}