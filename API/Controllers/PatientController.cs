using HMS_API.Model.DTOs;
using HMS_API.Model.Interfaces;
using HMS_API.Model.PatientHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IRepo<Patient, PatientDto> _repo;

        public PatientController(IRepo<Patient , PatientDto> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            return Ok(await _repo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!await _repo.IsExist(id))
            {
                return BadRequest("this Id is not Exist");
            }

            return Ok(await _repo.FindById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromForm]PatientDto patient)
        {
            return Ok(await _repo.Add(patient));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePtient([FromForm]PatientDto patient ,int id)
        {
            if (!await _repo.IsExist(id))
            {
                return BadRequest("this Id is not Exist !");
            }

            return Ok(await _repo.Update(patient , id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (!await _repo.IsExist(id))
            {
                return BadRequest("this Id is not Exist !");
            }

            return Ok(_repo.Delete(id));
        }
    }
}
