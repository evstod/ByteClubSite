using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages.Screen
{
    public class ManageModel : PageModel
    {
        public List<string> jsonStr = new List<string>();
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") < 1 || HttpContext.Session.GetInt32("access") == null)
            {
                return RedirectToPage("/ErrorAccessDenied");
            }
            var jsonFileReader = System.IO.File.OpenText("Pages/Screen/data/schedule.csv");
            jsonStr = jsonFileReader.ReadToEnd().Split("\n").ToList();
            jsonFileReader.Close();
            return Page();
        }
        public async Task OnGetChangeScheduleTimings(int s)
        {
            var jsonFileReader = System.IO.File.OpenText("Pages/Screen/data/schedule.csv");
            jsonStr = jsonFileReader.ReadToEnd().Split("\n").ToList();
            jsonFileReader.Close();
            jsonStr[0] = "type:" + s;
            foreach (var item in jsonStr)
            {
                await System.IO.File.WriteAllTextAsync("Pages/Screen/data/schedule.csv", item);
            }
        }
    }
}
