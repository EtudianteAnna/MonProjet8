namespace PatientApi.PatientModels
{
    public class AvailableCalendarDates
    {
        public DateTime? AvailableDate { get; set; }
        public DateTime? AvailableTime { get; set; }
        public int Id { get; internal set; }
    }
}
