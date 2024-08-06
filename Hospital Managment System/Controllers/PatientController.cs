using Hospital_Managment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_System.Controllers
{
    public class PatientController : Controller
    {
        private readonly IApi<Patient> _api;
        public PatientController()
        {
            _api = new ApiResponseHandler<Patient>();
        }

        public async Task<IActionResult> EmpIndex()
        {
            return View();
        }

        public async Task<IActionResult> RegisterPatient()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            return View();
        }

        public async Task<IActionResult> Patients()
        {
            //var result = await _api.GetAll("api/Patient/GetPatients");

            //return (result != null) ? View(result) : View();
            var patients = GetPatients();
            return View(patients);
        }


        private List<Patient> GetPatients()
        {
            // For demonstration purposes, creating a sample list of patients.
            // Replace this with actual data fetching logic.
            return new List<Patient>
            {
                new Patient { Id = 1, FirstName = "John", LastName = "Doe", Gender = "Male", Height = 180, Weight = 75, MaterialState = "Single", Address = "123 Main St", Date = DateTime.Now },
                new Patient { Id = 2, FirstName = "Jane", LastName = "Smith", Gender = "Female", Height = 165, Weight = 65, MaterialState = "Married", Address = "456 Maple Ave", Date = DateTime.Now },
                new Patient { Id = 3, FirstName = "Alice", LastName = "Johnson", Gender = "Female", Height = 170, Weight = 68, MaterialState = "Single", Address = "789 Oak Dr", Date = DateTime.Now }
            };
        }
    }
}
