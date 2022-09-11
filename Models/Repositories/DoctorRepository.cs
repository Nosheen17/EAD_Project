using Hospital.Models;
using Hospital.Models.Interfaces;

namespace Hospital.Models.Repositories
{
    public class DoctorRepository : IDoctorRepostitory
    {
        private readonly HospitalContext _context;

        public DoctorRepository()
        {
        }

        public DoctorRepository(HospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();  
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
