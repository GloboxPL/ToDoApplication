using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using ToDo.Database;
using ToDo.Models;
using ToDo.Models.DTO;

namespace ToDo.Services
{
    public class Auth
    {
        private readonly IToDoRepository _repo;

        public Auth(ToDoContext context)
        {
            _repo = new ToDoRepository(context);
        }

        public UserDTO CreateUser(string name, string surname, string email, string password)
        {
            password = Hashing.Hash(password);
            User user = new User(name, surname, email, password);
            var result = _repo.CreateUser(user);
            _repo.SaveChanges();
            return result;
        }

        public UserDTO Login(string email, string password)
        {
            var user = _repo.VerifyUser(email, password);
            return user;
        }

        public ClaimsPrincipal Authorize(UserDTO user)
        {
            if (user == null)
            {
                throw new System.Exception();
            }
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
    }
}