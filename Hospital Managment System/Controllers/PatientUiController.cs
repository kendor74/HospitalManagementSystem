using Hospital_Managment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Managment_System.Controllers
{
    public class PatientUiController : Controller
    {
        private readonly IApi<Patient> _api;
        public PatientUiController()
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
