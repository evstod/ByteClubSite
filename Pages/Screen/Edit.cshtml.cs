using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages.Screen
{
    public class EditModel : PageModel
    {

        private IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [BindProperty]
        public IFormFile Upload { get; set; } //Thing to check if there is a file specified in the form

        [BindProperty]
        public Agenda Agenda { get; set; }
        public string displayClass { get; set; } //for display on page
        public int displayPeriod { get; set; } //for display on page
        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("access") < 1 || HttpContext.Session.GetInt32("access") == null)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            Agenda = await _db.Agenda.FindAsync(id);

            displayClass = Agenda.Class;
            displayPeriod = Agenda.Id;
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Upload != null) //If there is a file specified in form
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot/img/uploads", Upload.FileName); //Set upload path
                using (var fileStream = new FileStream(file, FileMode.Create)) //Make file-uploader
                {
                    await Upload.CopyToAsync(fileStream); //upload file
                    fileStream.Close();
                }
            }
            if (ModelState.IsValid)
            {
                var ClassFromDb = await _db.Agenda.FindAsync(Agenda.Id);
                ClassFromDb.Class = Agenda.Class;
                ClassFromDb.Body = Agenda.Body;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
