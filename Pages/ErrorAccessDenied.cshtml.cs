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
        public bool LoginMsg { get; set; }
        public void OnGet()
        {
            if (HttpContext.Session.GetString("username") == null)
            {
                LoginMsg = false;
            }
            else
            {
                LoginMsg = true;
            }
        }
    }
}
