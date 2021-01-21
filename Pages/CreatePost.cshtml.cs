using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages
{
    public class CreatePostModel : PageModel
    {

        private IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        public CreatePostModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [BindProperty]
        public IFormFile Upload { get; set; } //Thing to check if there is a file specified in the form

        [BindProperty]
        public BlogPost BlogPost { get; set; } //Link to Models/BlogPost Object
        //TODO: Increment Id each creation
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("access") < 1 || HttpContext.Session.GetInt32("access") == null)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
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
                await _db.BlogPost.AddAsync(BlogPost);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
