using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaDataManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CoronaDataManagement.Pages.PatientData
{
    public class indexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public indexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Patient> Patients { get; set; }

        [BindProperty]
        public String SearchQwery { get; set; }
        public int TotalActive { get; set; }
        public int TotalRecovered { get; set; }
        public async Task OnGet()
        {
            if (SearchQwery !=null && SearchQwery.Length >= 1) {
               
                var SearchResults = _db.Patient.Where(name => name.PatientName.Contains(SearchQwery));
                Patients = await SearchResults.ToListAsync();

            }
            else
            {
                Patients = await _db.Patient.ToListAsync();

            }

            var TotalActiveLinq = from patient in Patients
                              where patient.PatientStatus.Equals("Positive")
                              select patient;
            TotalActive = TotalActiveLinq.Count();
            var TotalRecoveredLinq = from patient in Patients
                              where patient.PatientStatus.Equals("Positive")
                              select patient;
            TotalRecovered = TotalRecoveredLinq.Count();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var patient = await _db.Patient.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            _db.Patient.Remove(patient);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}