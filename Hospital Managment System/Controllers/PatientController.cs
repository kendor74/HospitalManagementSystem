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

        public async Task<IActionResult> Patients()
        {
            var result = await _api.GetAll("api/Patient/GetPatients");

            return (result != null) ? View(result) : View();
        }
    }
}
