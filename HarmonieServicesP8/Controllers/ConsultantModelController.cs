using HarmonieServicesP8.Models;
using Microsoft.AspNetCore.Mvc;

namespace PatientApi.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class ConsultantController : ControllerBase
    {
       
        private static readonly List<ConsultantModel> _consultants = new List<ConsultantModel>();

        [HttpPost]
        public IActionResult CreateConsultant([FromBody] ConsultantModel consultant)
        {
            consultant.Id = _consultants.Count + 1;
            _consultants.Add(consultant);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllConsultants()
        {
            return Ok(_consultants);
        }

        [HttpGet("{id}")]
        public IActionResult GetConsultant(int id)
        {
            var consultant = _consultants.FirstOrDefault(c => c.Id == id);
            if (consultant == null) return NotFound();
            return Ok(consultant);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConsultant(int id, [FromBody] ConsultantModel consultant)
        {
            var existingConsultant = _consultants.FirstOrDefault(c => c.Id == id);
            if (existingConsultant == null) return NotFound();
            existingConsultant.FirstName = consultant.FirstName;
            existingConsultant.Fname = consultant.Fname;
            existingConsultant.Lname = consultant.Lname;
            existingConsultant.Speciality = consultant.Speciality;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsultant(int id)
        {
            var existingConsultant = _consultants.FirstOrDefault(c => c.Id == id);
            if (existingConsultant == null) return NotFound();
            _consultants.Remove(existingConsultant);
            return Ok();
        }
    }
}
