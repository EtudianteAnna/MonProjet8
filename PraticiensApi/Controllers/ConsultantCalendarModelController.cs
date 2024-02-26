using Microsoft.AspNetCore.Mvc;
using PraticiensApi.PraticiensApiModels;

namespace PraticiensApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultantCalendarController : ControllerBase
    {
        private static readonly List<ConsultantCalendarModel> _consultantCalendars = new List<ConsultantCalendarModel>();

        [HttpPost]
        public IActionResult CreateConsultantCalendar([FromBody] ConsultantCalendarModel consultantCalendar)
        {
            // Vérifier si le modèle de calendrier du consultant est valide
            if (consultantCalendar == null || string.IsNullOrEmpty(consultantCalendar.ConsultantName))
            {
                return BadRequest("Invalid consultant calendar data");
            }

            // Générer un nouvel identifiant pour le calendrier du consultant
            consultantCalendar.Id = _consultantCalendars.Count + 1;

            // Ajouter le calendrier du consultant à la liste
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
            // Rechercher le calendrier du consultant par son ID
            var consultantCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (consultantCalendar == null)
            {
                return NotFound();
            }

            return Ok(consultantCalendar);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateConsultantCalendar(int id, [FromBody] ConsultantCalendarModel consultantCalendar)
        {
            // Rechercher le calendrier du consultant par son ID
            var existingCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (existingCalendar == null)
            {
                return NotFound();
            }

            // Mettre à jour les détails du calendrier du consultant
            existingCalendar.ConsultantName = consultantCalendar.ConsultantName;
            existingCalendar.AvailableDates = consultantCalendar.AvailableDates;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConsultantCalendar(int id)
        {
            // Rechercher le calendrier du consultant par son ID
            var existingCalendar = _consultantCalendars.FirstOrDefault(c => c.Id == id);
            if (existingCalendar == null)
            {
                return NotFound();
            }

            // Supprimer le calendrier du consultant de la liste
            _consultantCalendars.Remove(existingCalendar);

            return Ok();
        }
    }
}
