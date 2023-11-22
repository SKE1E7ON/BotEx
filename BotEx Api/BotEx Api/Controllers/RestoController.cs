using BotEx_Api.Model;
using BotEx_Api.ModelDTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using static BotEx_Api.ModelDTO.RestoransRequest;
using static BotEx_Api.ModelDTO.UserRequest;

namespace BotEx_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RestoController : ControllerBase
    {
        
        BotExContext DataBaseConnection = new BotExContext();
        [HttpPost]
        [Route("/restoPost")]
            
        public ActionResult<Restoran> AddRestorans([FromBody] RestoDTO restoran)
        {
            if (restoran != null)
            {
                Console.WriteLine("данные получены");
                List<Restoran> restorans = DataBaseConnection.Restorans.ToList();
                foreach (Restoran restoran1 in restorans)
                {
                    if (restoran1.Naming == restoran.Naming)
                    {
                        return Conflict();
                    }
                }
                restoran.RestoransId = DataBaseConnection.Restorans.Count() + 1;
                DataBaseConnection.Restorans.Add(RestoConverter(restoran));
                DataBaseConnection.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }




        JsonSerializerSettings mainSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        [HttpGet]
        [Route("/restoGetId/{idresto}")]
        public ActionResult<RestoGETRequest> RestoGetId( int idresto)
        {
            List<RestoGETRequest> restoGet = new List<RestoGETRequest>();
            List<Restoran> restorans = DataBaseConnection.Restorans.ToList().Where(x=>x.RestoransId == idresto).ToList();
            if(restorans != null) 
            {
                restoGet = RestoGETRequest.ConvertToGetRestos(restorans);
                return Content(JsonConvert.SerializeObject(restoGet, mainSettings));

            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("/restoGet")]
        public ActionResult<RestoGETRequest> RestoGet()
        {
            List<Restoran> restorans = DataBaseConnection.Restorans.ToList();
            if (restorans != null)
            {
                return Content(JsonConvert.SerializeObject(restorans, mainSettings));
            }
            else 
            { 
                return BadRequest(); 
            }
            

        }

    }
}
