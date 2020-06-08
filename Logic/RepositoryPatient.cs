using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoronaDataManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace CoronaDataManagement.Logic
{
    public class RepositoryPatient
    {
        private readonly ApplicationDbContext _db;

        public RepositoryPatient(ApplicationDbContext db)
        {
            _db = db;
        }
        public ApplicationDbContext applicationDbContext()
        {
            return _db;
        }
        public Task<Patient> Find(int id)
        {
            return _db.Patient.FirstOrDefaultAsync(g=>g.PatientId==id);
        }



    }
}
