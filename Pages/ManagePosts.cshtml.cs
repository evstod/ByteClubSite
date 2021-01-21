using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.JSInterop;

namespace ByteClubSite.Pages
{
    public class ManagePostsModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") != 1)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            return Page();
        }
    }
}
