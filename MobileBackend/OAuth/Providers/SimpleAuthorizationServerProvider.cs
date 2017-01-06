using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MySql.Data.MySqlClient;
using MobileBackend.Models;

namespace MobileBackend.OAuth.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public static string msj="";

        // OAuthAuthorizationServerProvider sınıfının client erişimine izin verebilmek için ilgili ValidateClientAuthentication metotunu override ediyoruz.
        public override async System.Threading.Tasks.Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        // OAuthAuthorizationServerProvider sınıfının kaynak erişimine izin verebilmek için ilgili GrantResourceOwnerCredentials metotunu override ediyoruz.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
             string str = context.Request.Headers.Get("User-Agent");

            DataTable dt = PR_TELEFON_NO_KONTROL(context.Password);

            if (dt.Rows.Count > 0)
            {

                var db = new HB_InsideEntities();

                var t = new personel_oturum
                {
                    OTURUM_BASLANGIC_TARIH = DateTime.Now,
                    OTURUM_BITIS_TARIH = DateTime.Now.AddDays(1),
                    SICIL_KOD = Convert.ToInt32(dt.Rows[0]["SICIL_KOD"]),
                    BEARER_TOKEN = "Dummy Token"
                };

                db.personel_oturum.Add(t);
                db.SaveChanges();

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                        identity.AddClaim(new Claim("sub", context.Password));
                        identity.AddClaim(new Claim("role", "user"));
                        context.Validated(identity);
                 
           }   
           else
           {
               //context.SetError("invalid_grant", "Authentication error!");
                context.SetError("invalid_grant", msj);
            }




          //  return result;
            // Kullanıcının access_token alabilmesi için gerekli validation işlemlerini yapıyoruz.

            //if (context.UserName == "Kutlu" && context.Password == "1234")

            //{
                
            //    var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            //    identity.AddClaim(new Claim("sub", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));

            //    context.Validated(identity);
                
            //}
            //else
            //{
            //    context.SetError("invalid_grant", "Kullanıcı adı veya şifre yanlış.");
            //}
        }
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["HB_Inside"].ConnectionString;
        }
       
        public static DataTable PR_TELEFON_NO_KONTROL(String P_TEL_NO)
        {
            DataTable Dt = new DataTable("PR_TELEFON_NO_KONTROL");
            try
            {

                MySqlCommand cmd = new MySqlCommand("PR_TELEFON_NO_KONTROL", new MySqlConnection(GetConnectionString())); ;
          
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("P_TEL_NO", P_TEL_NO);
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