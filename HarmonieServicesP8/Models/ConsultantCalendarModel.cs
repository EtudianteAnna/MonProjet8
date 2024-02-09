namespace PatientApi.Models
{ 

    public class ConsultantCalendarModel
    {
        public int Id { get; set; }
        public string? ConsultantName { get; set; }

        public List<DateTime>? AvailableDates { get; set; }
    }
}