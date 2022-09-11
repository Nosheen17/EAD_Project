using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Hospital.Models
{
    public partial class Doctor
    {
        public static List<Doctor> doc = new List<Doctor>();
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]

      [Required(ErrorMessage = "Username is required")] // username field is required
        public string Doc_Username { get; set; } = null!;
        [StringLength(5)]//length of password is 5
        [Required]
        [DataType(DataType.Password)]

        public string Doc_Password { get; set; } = null!;
        public string Departmant { get; set; } = null!;
      
        public int Mobile { get; set; }


        public static List<Doctor> printDoctor()//to print doctors
        {
            List<Doctor> doctors = new List<Doctor>();
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Doctor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Doctor u = new Doctor();

                u.Id = Convert.ToInt32(dr[0]);
                u.Doc_Username= Convert.ToString(dr[1]);
                u.Doc_Password = Convert.ToString(dr[2]);
                u.Departmant = Convert.ToString(dr[3]);
                u.Mobile = Convert.ToInt32(dr[4]);
                doctors.Add(u);
            }
            return doctors;
        }

        public static int AddDoctor(Doctor s)//to add Doctor in database
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);

            con.Open();
            //assigning the username and password

            string query = $"INSERT INTO Doctor(Doc_Username,Doc_Password,Departmant,Mobile) VALUES('{s.Doc_Username}','{s.Doc_Password}','{s.Departmant}','{s.Mobile}')";
            SqlCommand cmd = new SqlCommand(query, con);
            int insertedRows = cmd.ExecuteNonQuery();
            if (insertedRows >= 1)
            {
                con.Close();
                Doctor.AddSDoctors(s);
                return 1;
            }
            con.Close();
            return 2;
        }
        public static int ValidateDoctorLogin(Doctor u)
        {
            string conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Hospital;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query = $"SELECT * FROM Doctor WHERE Doc_Username=@u AND Doc_Password=@p";
            SqlParameter p1 = new SqlParameter("u", u.Doc_Username);
            SqlParameter p2 = new SqlParameter("p", u.Doc_Password);
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
        public static void AddSDoctors(Doctor d)
        {
            doc.Add(d);
        }

    }



}
