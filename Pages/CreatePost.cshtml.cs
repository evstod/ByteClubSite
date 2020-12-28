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
        public CreatePostModel(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [BindProperty]
        public IFormFile Upload { get; set; } //Thing to check if there is a file specified in the form

        [BindProperty]
        public BlogPost BlogPost { get; set; } //Link to Models/BlogPost Object
        //TODO: Increment Id each creation
        public void OnGet()
        {
        }

        public async Task OnPostAsync()
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


            string jsonOutput = JsonSerializer.Serialize<BlogPost>(BlogPost); //form data made into json entry
            using (var stream = new StreamWriter("data/posts.json", append: true)) //new writer that will append instead of overwrite
            {
                stream.WriteLine(jsonOutput); //put json serializer data in json file 
                stream.Flush();
                stream.Close();
            }
        }
    }
}
