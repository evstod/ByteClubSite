using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< Updated upstream
=======
using Microsoft.AspNetCore.Http;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages.Screen
{
    public class ManageModel : PageModel
    {
<<<<<<< Updated upstream
        public void OnGet()
        {
=======
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") < 1 || HttpContext.Session.GetInt32("access") == null)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            return Page();
>>>>>>> Stashed changes
        }
    }
}
