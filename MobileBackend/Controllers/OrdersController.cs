using MobileBackend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MobileBackend.Controllers
{

   

    public class OrdersController : ApiController
    {
        Order[] orders = new Order[]
     {
            new Order { Id = 1, Adet = 5},
            new Order { Id = 2,  Adet = 40 },
            new Order { Id = 3,   Adet = 94}
     };
       

        [HttpGet]
        [Authorize]
       
        public List<string> List()
        {
            List<string> orders = new List<string>();
            
            orders.Add("TH00000546");
            orders.Add("0001330782");
            orders.Add("Bu da Kutlunun order ı");

            return orders;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Order> GetAllOrders()
        {
            return orders;
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetOrder(int id)
        {
            var order = orders.FirstOrDefault((p) => p.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok( order);
            
        }
    }
}