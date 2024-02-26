using Microsoft.AspNetCore.Mvc;
using PatientApi.PatientModels;

namespace PatientApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private static readonly List<BookingModel> _bookings = new();

        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingModel booking)
        {
            // Vérifier si la réservation est valide
            if (booking == null || booking.Consultant == null || booking.Patient == null || booking.Appointment == null)
            {
                return BadRequest("Invalid booking data");
            }

            // Générer un nouvel identifiant pour la réservation
            booking.Appointment.AppointmentId = Guid.NewGuid();

            // Ajouter la réservation à la liste des réservations
            _bookings.Add(booking);

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(Guid id)
        {
            // Rechercher la réservation par son ID
            var booking = _bookings.FirstOrDefault(b => b.Appointment?.AppointmentId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(Guid id, [FromBody] BookingModel booking)
        {
            // Rechercher la réservation par son ID
            var existingBooking = _bookings.FirstOrDefault(b => b.Appointment?.AppointmentId == id);
            if (existingBooking == null)
            {
                return NotFound();
            }

            // Mettre à jour les détails de la réservation
            existingBooking.Patient = booking.Patient;
            existingBooking.Consultant = booking.Consultant;
            existingBooking.Facility = booking.Facility;
            existingBooking.Payment = booking.Payment;
            existingBooking.Appointment = booking.Appointment;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(Guid id)
        {
            // Rechercher la réservation par son ID
            var existingBooking = _bookings.FirstOrDefault(b => b.Appointment?.AppointmentId == id);
            if (existingBooking == null)
            {
                return NotFound();
            }

            // Supprimer la réservation de la liste des réservations
            _bookings.Remove(existingBooking);

            return Ok();
        }
    }
}
