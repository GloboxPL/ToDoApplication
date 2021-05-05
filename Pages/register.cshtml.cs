using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;
using ToDo.Models.DTO;
using ToDo.Services;

namespace ToDo.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
        private readonly Auth _auth;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterModel(ToDoContext context)
        {
            _auth = new Auth(context);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _auth.CreateUser(Name, Surname, Email, Password);
            if (user != null)
            {
                var principal = _auth.Authorize(user);
                await HttpContext.SignInAsync(principal);
                return RedirectToPage("./Assignments");
            }
            throw new System.NotImplementedException("niepoprawne dane logowania");
        }
    }
}
