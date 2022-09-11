//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;
//namespace Hospital.Models
//{

//    //public class Admin
//    //{
//    //    public static List<Admin> admins = new List<Admin>();
//    //    public int id { get; set; }
//    //    [Required(ErrorMessage = "*")] // username field is required
//    //    public string UserName { get; set; }
//    //    [StringLength(5)]//length of password is 5
//    //    [RegularExpression("([0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Password should be of length 5")]  //pattern for password is only digits     
//    //    [Required(ErrorMessage = "*")]
//    //    public string Password { get; set; }



//    //    public static int AddAdmin(Admin s)//to add Patients in database
//    //    {
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);

//    //        con.Open();
//    //        //assigning the username and password

//    //        string query = $"INSERT INTO Admin(Username,Password) VALUES('{s.UserName}','{s.Password}')";
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        int insertedRows = cmd.ExecuteNonQuery();
//    //        if (insertedRows >= 1)
//    //        {
//    //            Admin.AddSAdmins(s);
//    //            con.Close();
//    //            return 1;
//    //        }
//    //        con.Close();
//    //        return 2;
//    //    }
//    //    public static int ValidateAdminLogin(Admin u)
//    //    {
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);
//    //        con.Open();
//    //        string query = $"SELECT * FROM Admin WHERE Username=@u AND Password=@p";
//    //        SqlParameter p1 = new SqlParameter("u", u.UserName);
//    //        SqlParameter p2 = new SqlParameter("p", u.Password);
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        cmd.Parameters.Add(p1);
//    //        cmd.Parameters.Add(p2);
//    //        SqlDataReader dr = cmd.ExecuteReader();
//    //        if (dr.Read())
//    //        {
//    //            con.Close();
//    //            return 1;
//    //        }
//    //        con.Close();
//    //        return 2;
//    //    }

//    //    public static void AddSAdmins(Admin s)
//    //    {
//    //        admins.Add(s);
//    //    }

//    //    public static List<Admin> printAdmin()//to print admin
//    //    {
//    //        List<Admin> admins = new List<Admin>();
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);
//    //        con.Open();
//    //        string query = $"SELECT * FROM Admin";
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        SqlDataReader dr = cmd.ExecuteReader();
//    //        while (dr.Read())
//    //        {
//    //            Admin u = new Admin();
//    //            u.id = Convert.ToInt32(dr[0]);
//    //            u.UserName = Convert.ToString(dr[1]);
//    //            u.Password = Convert.ToString(dr[2]);
//    //            admins.Add(u);
//    //        }
//    //        return admins;
//    //    }
//    //}


//    //public class Doctor
//    //{
//    //    public static List<Doctor> doc = new List<Doctor>();

//    //    public int id { get; set; }
//    //    [Required(ErrorMessage = "Enter Username")] // username field is required
//    //    public string Doc_Username { get; set; }
//    //    [StringLength(5)]//length of password is 5
//    //    [RegularExpression("([0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Password should be of length 5")]  //pattern for password is only digits     
//    //    [Required(ErrorMessage = "*")]
//    //    public string Doc_Password { get; set; }
//    //    [Required(ErrorMessage = "Enter Department")] // password field is required
//    //    public string Department { get; set; }
//    //    [Required(ErrorMessage = "Mobile number is Required")]
//    //    [Range(0, 11)]
//    //    public int Mobile { get; set; }
//    //    public static List<Doctor> printDoctor()//to print doctors
//    //    {
//    //        List<Doctor> doctors = new List<Doctor>();
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);
//    //        con.Open();
//    //        string query = $"SELECT * FROM Doctor";
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        SqlDataReader dr = cmd.ExecuteReader();
//    //        while (dr.Read())
//    //        {
//    //            Doctor u = new Doctor();


//    //            u.Doc_Username = Convert.ToString(dr[1]);
//    //            u.Doc_Password = Convert.ToString(dr[2]);
//    //            u.Department = Convert.ToString(dr[3]);
//    //            u.Mobile = Convert.ToInt32(dr[4]);
//    //            doctors.Add(u);
//    //        }
//    //        return doctors;
//    //    }

//    //    public static int AddDoctor(Doctor s)//to add Doctor in database
//    //    {
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);

//    //        con.Open();
//    //        //assigning the username and password

//    //        string query = $"INSERT INTO Doctor(Doc_Username,Doc_Password,Departmant,Mobile) VALUES('{s.Doc_Username}','{s.Doc_Password}','{s.Department}','{s.Mobile}')";
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        int insertedRows = cmd.ExecuteNonQuery();
//    //        if (insertedRows >= 1)
//    //        {
//    //            con.Close();
//    //            Doctor.AddSDoctors(s);
//    //            return 1;
//    //        }
//    //        con.Close();
//    //        return 2;
//    //    }
//    //    public static int ValidateDoctorLogin(Doctor u)
//    //    {
//    //        string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//    //        SqlConnection con = new SqlConnection(conString);
//    //        con.Open();
//    //        string query = $"SELECT * FROM Doctor WHERE Doc_Username=@u AND Doc_Password=@p";
//    //        SqlParameter p1 = new SqlParameter("u", u.Doc_Username);
//    //        SqlParameter p2 = new SqlParameter("p", u.Doc_Password);
//    //        SqlCommand cmd = new SqlCommand(query, con);
//    //        cmd.Parameters.Add(p1);
//    //        cmd.Parameters.Add(p2);
//    //        SqlDataReader dr = cmd.ExecuteReader();
//    //        if (dr.Read())
//    //        {
//    //            con.Close();
//    //            return 1;
//    //        }
//    //        con.Close();
//    //        return 2;
//    //    }
//    //    public static void AddSDoctors(Doctor d)
//    //    {
//    //        doc.Add(d);
//    //    }
//    //}




//    public class Patient
//    {
//        public static List<Patient> pats = new List<Patient>();
//        public int id { get; set; }
//        [Required(ErrorMessage = "Enter Username")] // username field is required
//        public string Pat_Username { get; set; }
//        [StringLength(5)]//length of password is 5
//        [RegularExpression("([0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Password should be of length 5")]  //pattern for password is only digits     
//        [Required(ErrorMessage = "*")]
//        public string Pat_Password { get; set; }
//        [Required(ErrorMessage = "Enter Symptom")] // password field is required
//        public string Symptoms { get; set; }
//        [StringLength(11)]//length of password is 5
//        [RegularExpression("([0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Mobile Number should be of length 11")]  //pattern for password is only digits     
//        [Required(ErrorMessage = "*")]

//        public int Mobile { get; set; }
//        [Required(ErrorMessage = "Enter Department")] // password field is required
//        public string Department { get; set; }

//        public static int AddPatient(Patient s)//to add Patient in database
//        {
//            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection con = new SqlConnection(conString);

//            con.Open();
//            //assigning the username and password

//            string query = $"INSERT INTO Patient(Username,Password,Symptom,Mobile,Department) VALUES('{s.Pat_Username}','{s.Pat_Password}','{s.Symptoms}','{s.Mobile}','{s.Department}')";
//            SqlCommand cmd = new SqlCommand(query, con);
//            int insertedRows = cmd.ExecuteNonQuery();
//            if (insertedRows >= 1)
//            {
//                con.Close();
//                return 1;
//            }
//            con.Close();

//            return 2;
//        }
//        public static List<Patient> printPatient()//to print patients
//        {
//            List<Patient> pat = new List<Patient>();
//            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection con = new SqlConnection(conString);
//            con.Open();
//            string query = $"SELECT * FROM Patient";
//            SqlCommand cmd = new SqlCommand(query, con);
//            SqlDataReader dr = cmd.ExecuteReader();
//            while (dr.Read())
//            {
//                Patient u = new Patient();


//                u.Pat_Username = Convert.ToString(dr[1]);
//                u.Pat_Password = Convert.ToString(dr[2]);
//                u.Symptoms = Convert.ToString(dr[3]);
//                u.Mobile = Convert.ToInt32(dr[4]);
//                u.Department = Convert.ToString(dr[5]);
//                pat.Add(u);
//            }
//            return pat;
//        }
//        public static int ValidatePatientLogin(Patient u)
//        {
//            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
//            SqlConnection con = new SqlConnection(conString);
//            con.Open();
//            string query = $"SELECT * FROM Patient WHERE Username=@u AND Password=@p";
//            SqlParameter p1 = new SqlParameter("u", u.Pat_Username);
//            SqlParameter p2 = new SqlParameter("p", u.Pat_Password);
//            SqlCommand cmd = new SqlCommand(query, con);
//            cmd.Parameters.Add(p1);
//            cmd.Parameters.Add(p2);
//            SqlDataReader dr = cmd.ExecuteReader();
//            if (dr.Read())
//            {
//                con.Close();
//                return 1;
//            }
//            con.Close();
//            return 2;
//        }
//        public static void AddSPatient(Patient d)
//        {
//            pats.Add(d);
//        }
//    }
//}





