using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< Updated upstream
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
=======
using ByteClubSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
>>>>>>> Stashed changes

namespace ByteClubSite.Pages.Screen
{
    public class IndexModel : PageModel
    {
<<<<<<< Updated upstream
        public void OnGet()
        {
=======
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Agenda> Agendas;
        public async Task OnGet()
        {
            Agendas = await _db.Agenda.ToListAsync();
>>>>>>> Stashed changes
        }
    }
}
