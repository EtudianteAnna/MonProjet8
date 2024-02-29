using HarmonieServicesP8.Models;
using Microsoft.AspNetCore.Mvc;
using PraticiensApi.PraticiensApiModels;

namespace HarmonieServicesP8.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class ConsultantController : ControllerBase
    {
        // GET: api/Consultant
        [HttpGet]
        public IActionResult Get()
        {
            // Simuler la récupération des données des consultants depuis un service externe ou une base de données
            var consultants = new List<ConsultantModel>
            {
                new ConsultantModel { Id = 1, FirstName = "John", Fname = "John", Lname = "Doe", Speciality = "Cardiologist" },
                new ConsultantModel { Id = 2, FirstName = "Jane", Fname = "Jane", Lname = "Smith", Speciality = "Neurologist" }
            };

            // Simuler la récupération des données des calendriers des consultants depuis un service externe ou une base de données
            var consultantCalendars = new List<ConsultantCalendarModel>
            {
                new ConsultantCalendarModel { Id = 1, ConsultantName = "John Doe", AvailableDates = new List<DateTime> { DateTime.Today, DateTime.Today.AddDays(1) } },
                new ConsultantCalendarModel { Id = 2, ConsultantName = "Jane Smith", AvailableDates = new List<DateTime> { DateTime.Today.AddDays(2), DateTime.Today.AddDays(3) } }
            };

            // Créer un objet ConsultantModelList contenant à la fois les consultants et leurs calendriers associés
            var consultantModelList = new ConsultantModelList(consultants, consultantCalendars);

            return Ok(consultantModelList);
        }
    }
}
