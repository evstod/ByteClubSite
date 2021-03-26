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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Agenda> Agendas;
        public List<long> AgendasList = new List<long>();
        public int ScheduleTimings = 0;
        public int CurrentClassIndex = 0;
        public async Task OnGet()
        {
            var jsonFileReader = System.IO.File.OpenText("Pages/Screen/data/schedule.csv");
            ScheduleTimings = jsonFileReader.ReadToEnd().Split("\n")[0][5] - 48;
            jsonFileReader.Close();

            Agendas = await _db.Agenda.ToListAsync();

            foreach (var item in Agendas)
            {
                DateTime temp = DateTime.Now.Date; //Today but time is set to midnight
                if (ScheduleTimings == 0)
                {
                    temp += item.StartTime;
                }
                else if (ScheduleTimings == 1)
                {
                    temp += item.StartLate;
                }
                else if (ScheduleTimings == 2)
                {
                    temp += item.StartEarlyDismiss;
                }
                else if (ScheduleTimings == 3)
                {
                    temp += item.StartActivity;
                }

                AgendasList.Add((long)(temp - new DateTime(1970, 1, 1)).TotalMilliseconds);
            }
        }
    }
}
