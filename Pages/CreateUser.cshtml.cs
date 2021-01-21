using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages
{
    public class CreateUserModel : PageModel
    {

        private IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        public CreateUserModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [BindProperty]
        public UserLogin UserLogin { get; set; } //Link to Models/UserLogin Object
        public DateTime DateTime;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") != 2)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (ModelState.IsValid)
            {
                await _db.UserLogin.AddAsync(UserLogin);
                await _db.SaveChangesAsync();
                return RedirectToPage("CreateUser");
            }
            else
            {
                return Page();
            }
        }
    }
}