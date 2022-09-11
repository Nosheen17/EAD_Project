using Hospital.Models.Interfaces;

namespace Hospital.Models.Repositories
{
    public class AdminRepository:IAdminRepostitory
    {
        private readonly HospitalContext _context;

        public AdminRepository()
        {
        }

        public AdminRepository(HospitalContext context)
        {
            _context = context;
        }

        public IEnumerable<Admin> GetAll()
        {
            return _context.Admins.ToList();
        }

        public Admin GetById(int id)
        {
            return _context.Admins.Where(x => x.Id == id).FirstOrDefault();
        }
        public void AddAdmin(Admin s)//to add Patients in database
        {
            var AdmContext = new HospitalContext();
            var adm = AdmContext.Admins.ToList().Last();
            AdmContext.Admins.Add(s);
            AdmContext.SaveChanges();
            //string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection con = new SqlConnection(conString);

            //con.Open();
            ////assigning the username and password

            //string query = $"INSERT INTO Admin(Username,Password) VALUES('{s.Username}','{s.Password}')";
            //SqlCommand cmd = new SqlCommand(query, con);
            //int insertedRows = cmd.ExecuteNonQuery();
            //if (insertedRows >= 1)
            //{
            //    Admin.AddSAdmins(s);
            //    con.Close();
            //    return 1;
            //}
            //con.Close();
            //return 2;
        }
        public int ValidateAdminLogin(Admin u)
        {
            var admContext = new HospitalContext();
            int count = 0;

            if (admContext.Admins.Any(a => a.Username == u.Username && a.Password == u.Password))
            {
                count++;
            }

            return count;
            //string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection con = new SqlConnection(conString);
            //con.Open();
            //string query = $"SELECT * FROM Admin WHERE Username=@u AND Password=@p";
            //SqlParameter p1 = new SqlParameter("u", u.Username);
            //SqlParameter p2 = new SqlParameter("p", u.Password);
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.Parameters.Add(p1);
            //cmd.Parameters.Add(p2);
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    con.Close();
            //    return 1;
            //}
            //con.Close();
            //return 2;
        }

      
        public List<Admin> printAdmin()//to print admin
        {
            var adm = new HospitalContext();
            List<Admin> adms = new List<Admin>();
            adm.Admins.ToList().ForEach(a => adms.Add(a));
            return adms;
        }
    }
}
