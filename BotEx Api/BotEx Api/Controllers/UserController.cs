﻿using BotEx_Api.Model;
using BotEx_Api.ModelDTO;
using BotEx_Api.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using static BotEx_Api.ModelDTO.UserRequest;

namespace BotEx_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        BotExContext DataBaseConnection = new BotExContext();

<<<<<<< HEAD
=======
        [HttpPost]
        [Route("/users/add")]
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
        
>>>>>>> fc5d3d3bd804a0e8c310d838acb24c05b4216e64
        [HttpGet]
        [Route("/users/login")]
        public ActionResult<UserGetRequest> GetUserLogin(string login, string password) 
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Необходимо указать имя пользователя и пароль");
            }

            var users = DataBaseConnection.Users.FirstOrDefault(x=>x.Loggin == login && x.Password == password);
            if(users == null)
            {
                return BadRequest("данные введены не верно");
            }
            var tokenService = new TokenService("secretKey", "issuer", "audience");
            var token = tokenService.GenerateToken(users.Loggin);
            return Ok(new { Token = token });
        }

        [HttpPost]
        [Route("/users/regist")]
        public ActionResult<UserGetRequest> GetUserRegist(string login, string password, string returnpasword, string name, string adres, string phone)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Необходимо указать имя пользователя и пароль.");
            }

            var existingUser = DataBaseConnection.Users.FirstOrDefault(x=>x.Loggin == login);
            if (existingUser != null)
            {
                return BadRequest("Пользователь с таким логином уже существует.");
            }

            var existingPhone = DataBaseConnection.Users.FirstOrDefault(x => x.Phone == phone);
            if (existingPhone != null)
            {
                return BadRequest("Пользователь с таким номером уже существует.");
            }

            if (password != returnpasword)
            {
                return BadRequest("пароли не совпадают");
            }
            var newUser = new User {UsersId = DataBaseConnection.Users.Count() + 1, Loggin = login, Password = password, Name = name, AdresDefalt = adres, CardDefalt = "string", Phone = phone, IdRole = 1 };
            DataBaseConnection.Users.Add(newUser);
            DataBaseConnection.SaveChanges();
            return Ok("Регистрация прошла успешно.");
        }
    }

}
