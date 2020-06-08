using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CoronaDataManagement.Model;


namespace CoronaDataManagement.Pages.PatientData
{
    public class AddPatientModel : PageModel
    {
        
            private readonly ApplicationDbContext _db;

            public AddPatientModel(ApplicationDbContext db)
            {
                _db = db;
            }

            [BindProperty]
            public Patient Patient { get; set; }

            public async Task<IActionResult> OnPost()
            {
                if (ModelState.IsValid)
                {
                    await _db.Patient.AddAsync(Patient);
                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
                else
                {
                    return Page();
                }
            }
        
    }
}