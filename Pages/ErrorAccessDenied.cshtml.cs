using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages
{
    public class ErrorAccessDeniedModel : PageModel
    {
        public string Msg { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                Msg = "You are not logged in<p><a asp-page=\"/Login\">Go to Login</a></p>";
            }
            else
            {
                Msg = "<h3>You do not have permission to view this page.</h3>";
            }
        }
    }
}
