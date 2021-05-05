using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;
using ToDo.Services;

namespace ToDo.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        private readonly Auth _auth;

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsIncorrect { get; private set; }

        public IndexModel(ToDoContext context)
        {
            _auth = new Auth(context);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _auth.Login(Email, Password);
            if (user != null)
            {
                var principal = _auth.Authorize(user);
                await HttpContext.SignInAsync(principal);
                return RedirectToPage("./Assignments");
            }
            else
            {
                IsIncorrect = true;
                return Page();
            }
        }
    }
}
