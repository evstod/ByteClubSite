using ByteClubSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteClubSite.Controllers
{
    [Route("api/Agenda")]
    [ApiController]
    public class AgendaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AgendaController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Agenda.ToListAsync() });
        }
    }
}