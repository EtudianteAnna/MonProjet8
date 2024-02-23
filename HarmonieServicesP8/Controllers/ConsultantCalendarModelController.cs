using HarmonieServicesP8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HarmonieServicesP8.Controllers
{
    [ApiController]
    [Route("api/consultants/calendar")]
    public class ConsultantCalendarController : ControllerBase
    {
        private static readonly List<ConsultantCalendarModel> _consultantCalendars = new List<ConsultantCalendarModel>();

        [HttpPost]
        public IActionResult CreateConsultantCalendar([FromBody] ConsultantCalendarModel consultantCalendar)
        {

            if (consultantCalendar == null)
            {
                return BadRequest("Invalid consultant calendar");
            }


            consultantCalendar.Id = _consultantCalendars.Count + 1;
            _consultantCalendars.Add(consultantCalendar);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAllConsultantCalendars()
        {
            return Ok(_consultantCalendars);
        }

        [HttpGet("{id}")]
        public IActionResult GetConsultantCalendar(int id)
        {
            var consultantCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (consultantCalendar == null) return NotFound();
            return Ok(consultantCalendar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConsultantCalendar(int id, [FromBody] ConsultantCalendarModel consultantCalendar)
        {
            var existingCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (existingCalendar == null)
            {
                return NotFound();
            }
            existingCalendar.ConsultantName = consultantCalendar.ConsultantName;
            existingCalendar.AvailableDates = consultantCalendar.AvailableDates;
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsultantCalendar(int id)
        {
            var existingCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (existingCalendar == null)
            {
                return NotFound();
            }
            _consultantCalendars.Remove(existingCalendar);
            return Ok(); ;
        }
    }
}
