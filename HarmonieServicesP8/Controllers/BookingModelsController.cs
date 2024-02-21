using HarmonieServicesP8.Models;
using Microsoft.AspNetCore.Mvc;

namespace HarmonieServicesP8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateBooking([FromBody] BookingModel booking)
        {
            // Logique pour créer une réservation
            return Ok(); // Renvoyer une réponse 200 OK si la réservation est créée avec succès
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            // Logique pour récupérer une réservation par son ID
            return Ok(); // Renvoyer une réponse 200 OK avec la réservation correspondante
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBooking(int id, [FromBody] BookingModel booking)
        {
            // Logique pour mettre à jour une réservation
            return Ok(); // Renvoyer une réponse 200 OK si la réservation est mise à jour avec succès
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            // Logique pour supprimer une réservation
            return Ok(); // Renvoyer une réponse 200 OK si la réservation est supprimée avec succès
        }
    }
}
