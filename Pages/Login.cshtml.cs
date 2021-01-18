using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ByteClubSite.Pages
{
    public class LoginModel : PageModel
    {
        private IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        public LoginModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }
        public void OnGet()
        {
        
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public string Msg = "";

        public IEnumerable<UserLogin> UserLogins { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            UserLogins = await _db.UserLogin
                .Where(b => b.Username == Username)
                .ToListAsync();
            foreach (var entry in UserLogins)
            {
                if (entry.Password == Password)
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("Index");
                }
            }
            Msg = "Invalid Credentials.";
            return Page();
        }
    }
}
