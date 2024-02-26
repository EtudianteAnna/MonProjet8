using Microsoft.AspNetCore.Mvc;

namespace HarmonieServicesP8.Controllers
{
    [ApiController]
    [Route("api/availabilities")]
    public class AvailableCalendarDatesController : ControllerBase
    {

        private static readonly List<AvailableCalendarDatesController> _availableDatesList = new();

        [HttpPost]
        public IActionResult CreateAvailableDate([FromBody] AvailableCalendarDatesController availableDate)
        {
            if (availableDate == null)
            {
                return BadRequest("Date non disponible");
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
            // Logique pour récupérer une date disponible par son ID
            // Par exemple :
            // var availableDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            // if (availableDate == null) return NotFound();
            // return Ok(availableDate);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAvailableDate(int id, [FromBody] AvailableCalendarDatesController availableDate)
        {
            // Logique pour mettre à jour une date disponible
            // Par exemple :
            // var existingDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            // if (existingDate == null) return NotFound();
            // existingDate.AvailableDate = availableDate.AvailableDate;
            // existingDate.AvailableTime = availableDate.AvailableTime;
            // return Ok();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAvailableDate(int id)
        {
            // Logique pour supprimer une date disponible
            // Par exemple :
            // var existingDate = _availableDatesList.FirstOrDefault(date => date.Id == id);
            // if (existingDate == null) return NotFound();
            // _availableDatesList.Remove(existingDate);
            // return Ok();
            return Ok();
        }
    }
}
