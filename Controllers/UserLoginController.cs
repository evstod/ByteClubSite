using ByteClubSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ByteClubSite.Controllers
{
    [Route("api/UserLogin")]
    [ApiController]
    public class UserLoginController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserLoginController(ApplicationDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.UserLogin.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var userFromDb = await _db.BlogPost.FirstOrDefaultAsync(u => u.Id == id);
            if (userFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.BlogPost.Remove(userFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}