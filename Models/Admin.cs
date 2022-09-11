using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Hospital.Models
{
    public partial class Admin
    {
        public static List<Admin> admins = new List<Admin>();
        public int Id { get; set; }
        [Required(ErrorMessage = "Username is required")] // username field is required
        [StringLength(20, ErrorMessage = "Length should not exceed 20 characters")]

        public string Username { get; set; } = null!;
       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        

    }
}
