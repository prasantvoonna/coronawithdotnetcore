using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoronaDataManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaDataManagement.Controllers
{
    [Route("api/patients")]
    [ApiController]
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PatientsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new { data = await _db.Patient.ToListAsync() });
/*            return Json(new { data = await _db.Patient.Where(u => u.PatientName.Contains("P")) });
*/        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Patient.FirstOrDefaultAsync(u => u.PatientId == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Patient.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}