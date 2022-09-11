using Hospital.Models.Interfaces;

namespace Hospital.Models.Repositories
{
    public class PatientRepository: IPatientRepostitory
    {
        private readonly HospitalContext _context;

        public PatientRepository()
        {
        }

        public PatientRepository(HospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
