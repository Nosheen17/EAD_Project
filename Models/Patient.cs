using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Hospital.Models
{
    public partial class Patient
    {
        public static List<Patient> pats = new List<Patient>();
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")] // username field is required
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]

        public string Username { get; set; } = null!;
        [StringLength(5)] //length of password is 5
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Symptom is required")] // password field is required        
        public string Symptom { get; set; } = null!;
      
        [RegularExpression("([0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9])", ErrorMessage = "Mobile Number should be of length 11")]  //pattern for password is only digits     
        [Required(ErrorMessage = "Mobile number is required")]
        public int Mobile { get; set; }
        [Required(ErrorMessage = "Department field is required")] 
                                                     
        public string Department { get; set; } = null!;

        public static int AddPatient(Patient s)//to add Patient in database
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            //assigning the username and password

            string query = $"INSERT INTO Patient(Username,Password,Symptom,Mobile,Department) VALUES('{s.Username}','{s.Password}','{s.Symptom}','{s.Mobile}','{s.Department}')";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                con.Close();
                Patient.AddSPatient(s);
                return 1;
            }
            con.Close();

            return 2;
        }
        public static List<Patient> printPatient()//to print patients
        {
            List<Patient> pat = new List<Patient>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Patient";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Patient u = new Patient();


                u.Username = Convert.ToString(dr[1]);
                u.Password = Convert.ToString(dr[2]);
                u.Symptom = Convert.ToString(dr[3]);
                u.Mobile = Convert.ToInt32(dr[4]);
                u.Department = Convert.ToString(dr[5]);
                pat.Add(u);
            }
            return pat;
        }
        public static int ValidatePatientLogin(Patient u)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Patient WHERE Username=@u AND Password=@p";
            SqlParameter p1 = new SqlParameter("u", u.Username);
            SqlParameter p2 = new SqlParameter("p", u.Password);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return 1;
            }
            con.Close();
            return 2;
        }
        public static void AddSPatient(Patient d)
        {
            pats.Add(d);
        }
        public static List<Patient> printCurrentPatient(Patient u)//to print patients
        {
            List<Patient> pat = new List<Patient>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Patient WHERE Username=@u AND Password=@p";
            SqlParameter p1 = new SqlParameter("u", u.Username);
            SqlParameter p2 = new SqlParameter("p", u.Password);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

          
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Patient p = new Patient();


                p.Username = Convert.ToString(dr[1]);
                p.Password = Convert.ToString(dr[2]);
                p.Symptom = Convert.ToString(dr[3]);
                p.Mobile = Convert.ToInt32(dr[4]);
                p.Department = Convert.ToString(dr[5]);
                pat.Add(p);
            }
            return pat;
        }
    }
  
}
