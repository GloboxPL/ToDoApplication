using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ToDo.Database;

namespace ToDo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IToDoRepository _repo;

        public IndexModel(ILogger<IndexModel> logger, ToDoContext context)
        {
            _repo = new ToDoRepository(context);
            _logger = logger;
            InitializeTechnologies();
        }

        public Dictionary<string, string> Technologies { get; private set; }

        public void OnGet()
        {
            // example how to get/set db data in controller
            // _repo.CreateUser(new Models.User("John", "Kowalsky", "johny@mail.com", "passwordHash"));
            // _repo.SaveChanges();
        }

        private void InitializeTechnologies()
        {
            Technologies = new Dictionary<string, string>();
            Technologies.Add("C#", "https://earlycode.net/img/c-sharp.png");
            Technologies.Add(".NET 5", "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a3/.NET_Logo.svg/1200px-.NET_Logo.svg.png");
            Technologies.Add("ASP.NET Core", "https://raw.githubusercontent.com/campusMVP/dotnetCoreLogoPack/master/ASP.NET%20Core/Bitmap%20RGB/Bitmap-BIG_ASP.NET-Core-Logo_2colors_Square_Boxed_RGB.png");
            Technologies.Add("Razor Pages", "https://ppolyzos.com/wp-content/uploads/2016/09/asp-net-core-razor-view.jpg");
            Technologies.Add("Entity Framework Core", "https://res.cloudinary.com/satvasolutions-com/image/upload/v1514380871/imgpsh_fullsize_lydh09.jpg");
            Technologies.Add("PostgreSQL", "https://certfirst.com/wp-content/inventory_images/PostgreSQL%20DBA%20logo17.bmp");
            Technologies.Add("Docker", "https://media.vlpt.us/images/melangyun/post/445f422b-fccb-441d-b726-81bd2e53e2a7/New_Docker_logo_Logo.jpg");
        }
    }
}
