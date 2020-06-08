using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoronaDataManagement.Model;
using CoronaDataManagement.Logic;

namespace CoronaDataManagement.Pages.PatientData
{
    public class EditPatientModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        private readonly RepositoryPatient _repo;
        public EditPatientModel(ApplicationDbContext db)
        {
            this._repo = new RepositoryPatient(_db);
            this._db = db;
        }

        [BindProperty]
        public Patient Patient { get; set; }

        public async Task OnGet(int id)
        {
            Patient = await _repo.Find(id);
        }
        
        public async Task<IActionResult> OnPost()
        { 
            if (ModelState.IsValid)
            {
                var PatientFromDb = await _db.Patient.FindAsync(Patient.PatientId);
                PatientFromDb.PatientName = Patient.PatientName;
                PatientFromDb.PatientStatus = Patient.PatientStatus;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}