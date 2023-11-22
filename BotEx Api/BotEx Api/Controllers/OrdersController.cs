using BotEx_Api.Model;
using BotEx_Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static BotEx_Api.ModelDTO.OrdersRequest;

namespace BotEx_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        BotExContext DataBaseConnection = new BotExContext();
        JsonSerializerSettings mainSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        [HttpGet]
        [Route("/OrdersGet/{id}")]
        public ActionResult<OrdersGETRequest> GetOrdersId(int id) 
        {
            List<OrdersGETRequest> gETRequests = new List<OrdersGETRequest>();
            List<Order> orders = DataBaseConnection.Orders.ToList().Where(x=>x.IdOrders == id).ToList();
            if(orders != null)
            {
                gETRequests = OrdersGETRequest.ConvertToGet(orders);
                return Content(JsonConvert.SerializeObject(gETRequests, mainSettings));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost]
        [Route("/OrdersPost")]
        public ActionResult<Order> AddOrders([FromBody] OrdersDTO orders)
        {
            if (orders != null)
            {
                List<Order> orderList = new List<Order>();
                foreach (Order order in orderList)
                {
                    if (order.IdOrders == orders.IdOrders)
                    {
                        return Conflict();
                    }
                }
                orders.IdOrders = DataBaseConnection.Orders.Count() + 1;
                DataBaseConnection.Orders.Add(OrderConverter(orders));
                DataBaseConnection.SaveChanges();
                return Ok();
            }
            return BadRequest();
        } 
    }
}
