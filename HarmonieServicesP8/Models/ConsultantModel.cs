namespace HarmonieServicesP8.Models
{
    public class ConsultantModel
    {
        public string? FirstName { get; set; }
        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Speciality { get; set; }
    }
    public class ConsultantModelList
    {
        public List<ConsultantModel> Consultants { get; set; }
        public List<ConsultantCalendarModel> ConsultantCalendars { get; set; }

        public ConsultantModelList(List<ConsultantModel> consultants, List<ConsultantCalendarModel> consultantCalendars)
        {
            Consultants = consultants ?? throw new ArgumentNullException(nameof(consultants));
            ConsultantCalendars = consultantCalendars ?? throw new ArgumentNullException(nameof(consultantCalendars));
        }

        // Deuxième constructeur prenant uniquement la liste de ConsultantModel
        public ConsultantModelList(List<ConsultantModel> consultants)
        {
            Consultants = consultants ?? throw new ArgumentNullException(nameof(consultants));
            ConsultantCalendars = new List<ConsultantCalendarModel>(); // Initialisation avec une liste vide
        }




    }




}
