using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ByteClubSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ByteClubSite.Pages.Screen
{
    public class EditScheduleModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditScheduleModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public List<Agenda> Agendas { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Agendas = await _db.Agenda.ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            foreach (Agenda data in Agendas)
            {
                if (!data.Active)
                {
                    data.Class = "_"; data.Body = "_";
                }
            }
            int i = 1; //Yes I know incrementing a variable inside a for loop makes no sense, but just using data.Id doesn't work for reasons I don't quite understand
            //EDIT: It was because SQL tables do not start from 0
            foreach (Agenda data in Agendas)
            {
                if (ModelState.IsValid)
                {
                    var AgendaFromDb = _db.Agenda.Find(i);
                    AgendaFromDb.Class = data.Class;
                    AgendaFromDb.StartTime = data.StartTime;
                    AgendaFromDb.StartLate = data.StartLate;
                    AgendaFromDb.StartEarlyDismiss = data.StartEarlyDismiss;
                    AgendaFromDb.StartActivity = data.StartActivity;
                    AgendaFromDb.Active = data.Active;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    return RedirectToPage("Index");
                }
                i++;
            }
            return RedirectToPage("Index");
        }
    }
}
