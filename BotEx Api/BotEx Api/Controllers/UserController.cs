using BotEx_Api.Model;
using BotEx_Api.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using System.Data;
using static BotEx_Api.ModelDTO.UserRequest;

namespace BotEx_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        BotExContext DataBaseConnection = new BotExContext();

        [HttpPost]
        [Route("/users")]
        public ActionResult<User> ClientRegistration([FromBody] UsersDTO user)
        {
            if (user != null)
            {
                List<User> users = DataBaseConnection.Users.ToList();
                foreach(User claimsPrincipal in users)
                {
                    if (claimsPrincipal.Loggin == user.Loggin) 
                    {
                        return Conflict();
                    }
                }
                user.Id = DataBaseConnection.Users.Count() + 1;
                DataBaseConnection.Users.Add(UserConverter(user));
                DataBaseConnection.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }

}
