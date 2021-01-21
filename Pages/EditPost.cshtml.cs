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
using Microsoft.EntityFrameworkCore;

namespace ByteClubSite.Pages
{
    public class EditPostModel : PageModel
    {

        private IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _db;
        public EditPostModel(IWebHostEnvironment environment, ApplicationDbContext db)
        {
            _environment = environment;
            _db = db;
        }

        [BindProperty]
        public IFormFile Upload { get; set; } //Thing to check if there is a file specified in the form

        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            if (HttpContext.Session.GetInt32("access") != 1)
            {
                return RedirectToPage("ErrorAccessDenied");
            }
            BlogPost = await _db.BlogPost.FindAsync(id);
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
                var BookFromDb = await _db.BlogPost.FindAsync(BlogPost.Id);
                BookFromDb.Title = BlogPost.Title;
                BookFromDb.Author = BlogPost.Author;
                BookFromDb.Body = BlogPost.Body;

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
