using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDo.Database;
using ToDo.Models;

namespace ToDo.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repo;

        public ToDoController(ToDoContext context)
        {
            _repo = new ToDoRepository(context);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult Login()
        {
            User user = new User("Jan", "Kowalski","email@email.com", "zaq1@WSX");
            TokenManager manager = new TokenManager();

            Console.WriteLine(manager.GenerateToken(user));
            return Ok();
        }

        [HttpPost("newuser")]
        public ActionResult NewUser()
        {
            throw new System.NotImplementedException();
        }

        [HttpGet("assignments")]
        public ActionResult GetAssignments()
        {
            throw new System.NotImplementedException();
        }
    }
}