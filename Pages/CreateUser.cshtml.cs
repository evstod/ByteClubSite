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
        public bool hasEditorRightsTemp { get; set; } //To translate to UserLogin as int
        public string Msg { get; set; } //Input Error messages
        public DateTime DateTimeNow = DateTime.Now;
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") < 2 || HttpContext.Session.GetInt32("access") == null)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (UserLogin.Username.Length > 50)
            {
                Msg = "Username must be 50 characters or less.";
                return Page();
            }
            if (UserLogin.Password.Length > 50)
            {
                Msg = "Password must be 50 characters or less.";
                return Page();
            }

            if (hasEditorRightsTemp)
            {
                UserLogin.hasEditorRights = 1;
            }
            else
            {
                UserLogin.hasEditorRights = 0;
            }
            if (ModelState.IsValid)
            {
                UserLogin.createDate = DateTimeNow;
                await _db.UserLogin.AddAsync(UserLogin);
                await _db.SaveChangesAsync();
                return RedirectToPage("CreateUser");
            }
            else
            {
                Msg = "An error has occured in validating the login information.";
                return Page();
            }
        }
    }
}
