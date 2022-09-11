namespace Hospital.Models.Interfaces
{
    public interface IDoctorRepostitory
    {
        IEnumerable<Doctor> GetAll();
        Doctor GetById(int id);
    }
    public interface IAdminRepostitory
    {
        IEnumerable<Admin> GetAll();
        Admin GetById(int id);
        void AddAdmin(Admin s);
        int ValidateAdminLogin(Admin u);
        List<Admin> printAdmin();
    }
    public interface IPatientRepostitory
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int id);
    }
    
}
