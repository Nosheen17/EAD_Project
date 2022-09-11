using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
namespace Hospital.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IWebHostEnvironment Environment;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment environment,UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
            Environment = environment;
            _logger = logger;
        }
         public IActionResult Index()
        {
            string data = String.Empty;
            if (HttpContext.Session.Keys.Contains("first_request"))
            {
                string firstVisitedDateTime = HttpContext.Session.GetString("first_request");
                data = "Welcome back " + firstVisitedDateTime;

            }
            else
            {
                
                data = "you visited first time";
                HttpContext.Session.SetString("first_request", System.DateTime.Now.ToString());
            }
            return View("index", data);
        }

        public IActionResult Remove()
        {
            HttpContext.Session.Remove("first_request");
            return View("Index");
        }

        public ViewResult HomePage()
        {
            return View();
        }
        public ViewResult AdminButton()
        {
            return View();
        }
        public ViewResult DoctorButton()
        {
            return View();
        }
        public ViewResult PatientButton()
        {
            return View();
        }
        [HttpGet]
        public ViewResult AdminSignUp()
        {
            return View();
        }
        //[HttpPost]
        //public ViewResult AdminSignUp(Models.Admin a)
        //{

        //    Models.Admin.AddSAdmins(a);
        //    if (Models.Admin.AddAdmin(a) == 1)//entered info will be passed to be stored in database
        //    {

        //        return base.View("AdminLoginPage");
        //    }
        //    else
        //        return base.View();
        //}
        [HttpPost]
        public async Task<IActionResult> AdminSignUp(Models.Admin a)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = a.Username, PasswordHash = a.Password };
                var result = await userManager.CreateAsync(user, a.Password);
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("AdminLoginPage");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(a);
        }

        [HttpGet]
        public IActionResult AdminLoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLoginPage(Admin model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Username, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return View("redirectToAdmin");
                }
                
                   
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                return View("Error");
            }

            return View(model);
        }
        public ViewResult DoctorSignUp()
        {
            return View();
        }
        [HttpPost]
        public ViewResult DoctorSignUp(Doctor a)
        {
            if (ModelState.IsValid)
            {
                Doctor.AddSDoctors(a);

                if (Doctor.AddDoctor(a) == 1)//entered info will be passed to be stored in database
                {

                    return View("DoctorLoginPage");
                }
            }
          
                return View();
        }
        public ViewResult PatientSignUp()
        {
            ViewBag.Doctors = Doctor.printDoctor();
            return View();
        }
        [HttpPost]
        public ViewResult PatientSignUp(Patient a)
        {
            Patient.AddSPatient(a);
            if (Patient.AddPatient(a) == 1)//entered info will be passed to be stored in database
            {

                return View("PatientLoginPage");
            }
            else
                return View();
        }

        public ViewResult doctor_dashboard()
        {
            return View();
        }
        public ViewResult doctor_appointment()
        {
            return View();
        }
        public ViewResult doctor_view_appointment()
        {
            return View();
        }
        public ViewResult doctor_delete_appointment()
        {
            return View();
        }


        //public ViewResult AdminLoginPage()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ViewResult AdminLoginPage(Models.Admin a)
        //{
        //    if (ModelState.IsValid) //model validation
        //    {

        //        if (Models.Admin.ValidateAdminLogin(a) == 1)
        //        {


        //            ModelState.Clear(); //to clear previous data entered if any

        //            return base.View("redirectToAdmin");


        //        }
        //        else
        //            return base.View("Error");
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}
        public ViewResult DoctorLoginPage()
        {
            return View();
        }

        [HttpPost]
        public ViewResult DoctorLoginPage(Models.Doctor a)
        {
            
                if (Models.Doctor.ValidateDoctorLogin(a) == 1)
                {


                    ModelState.Clear(); //to clear previous data entered if any

                    return base.View("redirectToDoctor", a);


                }
                else
                    return base.View("Error");
            
           


        }
        public ViewResult PatientLoginPage()
        {
            return View();
        }

        [HttpPost]
        public ViewResult PatientLoginPage(Patient a)
        {
            ViewModel mymodel = new ViewModel();
            mymodel.Pats = Patient.printCurrentPatient(a);
            ViewBag.pat = Patient.printCurrentPatient(a);

            if (Patient.ValidatePatientLogin(a) == 1)
                {


                    ModelState.Clear(); //to clear previous data entered if any
                    return View("patient_dashboard", mymodel);


                }
                else
                    return View("Error");
           
        }
    
        public ViewResult admin_dashboard()
        {

            ViewModel mymodel = new ViewModel();
            mymodel.Docs = Doctor.printDoctor();
            mymodel.Pats = Patient.printPatient();

            ViewBag.pat = Patient.printPatient();

            List<Patient> pat = new List<Patient>();
            pat = Patient.printPatient();
            ViewBag.patients = Patient.printPatient();
            int num1 = pat.Count;
            ViewBag.patCount = num1;
            List<Doctor> students = new List<Doctor>();
            students = Doctor.printDoctor(); //a students list will be created to be printed
            int num = students.Count;
            ViewBag.docCount = num;
            ModelState.Clear(); //to clear previous data entered if any
            return View("admin_dashboard_cards", mymodel);
        }
        public ViewResult admin_dashboard_doctor()
        {
            return View();
        }
        public ViewResult admin_doc_view()
        {
            List<Doctor> students = new List<Doctor>();

            students = Doctor.printDoctor(); //a students list will be created to be printed
            ModelState.Clear(); //to clear previous data entered if any
            return View("admin_view_doctor", students);

        }


        public ViewResult admin_doc_add()
        {
            return View();
        }
        [HttpPost]
        public ViewResult admin_doc_add(Doctor a)
        {
            Doctor.AddSDoctors(a);

            if (Doctor.AddDoctor(a) == 1)//entered info will be passed to be stored in database
            {

                return View("admin_dashboard_doctor");
            }
            else
                return View();
        }
        public ViewResult admin_pat_view()
        {
            List<Patient> pat = new List<Patient>();
            pat = Patient.printPatient(); //a students list will be created to be printed
            ModelState.Clear(); //to clear previous data entered if any
            return View("admin_view_patient", pat);
        }
        public ViewResult Error()
        {


            return View();
        }
        public ViewResult discharge_patient()
        {
            List<Patient> pat = new List<Patient>();
            pat = Patient.printPatient(); //a students list will be created to be printed
            ModelState.Clear(); //to clear previous data entered if any
            return View("patient_discharge", pat);
        }
        public ViewResult patient_dischargeBill()
        {
            return View();
        }

        public ViewResult admin_specialization()
        {
            List<Doctor> students = new List<Doctor>();
            students = Doctor.printDoctor(); //a students list will be created to be printed
            ModelState.Clear(); //to clear previous data entered if any
            return View("admin_special", students);

        }
        public ViewResult admin_patient()
        {

            return View();
        }
        public ViewResult admin_admit_patient()
        {
            ViewBag.Doctors = Doctor.printDoctor();
            return View();
        }
        [HttpPost]
        public ViewResult admin_admit_patient(Patient a)
        {

            Patient.AddSPatient(a);

            if (Patient.AddPatient(a) == 1)//entered info will be passed to be stored in database
            {

                return View("admin_patient");
            }
            else
                return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult patient_dashboard()
        {
            return View();
        }
        public ViewResult patient_appointment()
        {
            return View();
        }
        public ViewResult patient_bookAppointment()
        {
            ViewBag.Doctors = Doctor.printDoctor();
            return View();
        }


    }

}