using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDo.Database;

namespace ToDo.Pages
{
    public class AddModel : PageModel
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsImportant { get; set; }
        public bool IsDone { get; set; }
        public DateTime Deadline { get; set; }
        public string Color { get; set; }



        public IActionResult OnPost()
        {
            return RedirectToPage("./Assignments");
        }
    }
}
