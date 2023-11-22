using BotEx_Api.Model;
using BotEx_Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotEx_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        BotExContext DataBaseConnection = new BotExContext();
        JsonSerializerSettings mainSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        [HttpGet]
        [Route("/Menu/{id}")]
        public ActionResult<MenuGETRequest> GetMenuId(int id)
        {
            List<MenuGETRequest> GetMenuRequest = new List<MenuGETRequest>();
            List<Menu> menus = DataBaseConnection.Menus.ToList().Where(x=>x.MenuId == id).ToList();
            if(menus != null)
            {
                GetMenuRequest = MenuGETRequest.ConvertToGet(menus);
                return Content(JsonConvert.SerializeObject(GetMenuRequest, mainSettings));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
