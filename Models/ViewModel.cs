namespace Hospital.Models
{
    public class ViewModel
    {
        public IEnumerable<Doctor> Docs { get; set; }
        public IEnumerable<Patient> Pats { get; set; }
    }
}
