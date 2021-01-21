using ByteClubSite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteClubSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public string Username { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public async Task OnGet()
        {
            BlogPosts = await _db.BlogPost.ToListAsync();
            Username = HttpContext.Session.GetString("username");
        }
    }
}
