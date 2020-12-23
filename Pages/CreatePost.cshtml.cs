using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ByteClubSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ByteClubSite.Pages
{
    public class CreatePostModel : PageModel
    {
        [BindProperty]
        public BlogPost BlogPost { get; set; } //Link to Models/BlogPost Object
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string jsonOutput = JsonSerializer.Serialize<BlogPost>(BlogPost); //form data made into json entry
            System.IO.File.WriteAllText("wwwroot/data/posts.json", jsonOutput); //put json serializer data in json file 
        }
    }
}
