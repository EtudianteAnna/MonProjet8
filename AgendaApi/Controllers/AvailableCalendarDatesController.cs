using Microsoft.AspNetCore.Mvc;
using PatientApi.PatientModels;

namespace PatientApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailableCalendarDatesController : ControllerBase
    {
        private static readonly List<AvailableCalendarDates> _availableDatesList = new();

        [HttpPost]
        public IActionResult CreateAvailableDate([FromBody] AvailableCalendarDates availableDate)
        {
            if (availableDate == null)
            {
                return BadRequest("Invalid available date");
            }

            _availableDatesList.Add(availableDate);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllAvailableDates()
        {
            return Ok(_availableDatesList);
        }

        [HttpGet("{id}")]
        public IActionResult GetAvailableDate(int id)
        {
            var availableDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            if (availableDate == null)
            {
                return NotFound();
            }
            return Ok(availableDate);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAvailableDate(int id, [FromBody] AvailableCalendarDates availableDate)
        {
            var existingDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            if (existingDate == null)
            {
                return NotFound();
            }
            existingDate.AvailableDate = availableDate.AvailableDate;
            existingDate.AvailableTime = availableDate.AvailableTime;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAvailableDate(int id)
        {
            var existingDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            if (existingDate == null)
            {
                return NotFound();
            }
            _availableDatesList.Remove(existingDate);
            return Ok();
        }
    }
}
