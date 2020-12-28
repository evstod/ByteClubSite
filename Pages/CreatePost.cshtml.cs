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

            List<BlogPost> jsonList = new List<BlogPost>(); //List of Blog Posts
            using (StreamReader stream = new StreamReader("wwwroot/data/posts.json"))
            {
                jsonList = JsonSerializer.Deserialize<List<BlogPost>>(stream.ReadToEnd()); //Add pre-existing blog posts to list
                stream.Close();
            }
            jsonList.Add(BlogPost); //add the new entry to list
            string jsonOutput = JsonSerializer.Serialize<List<BlogPost>>(jsonList); //turn list into json-formatted string
            using (StreamWriter stream = new StreamWriter("wwwroot/data/posts.json", append: false)) //new writer that will overwrite
            {
                stream.Write(jsonOutput); //put json serializer data in json file 
                stream.Flush();
                stream.Close();
            }
        }
    }
}
