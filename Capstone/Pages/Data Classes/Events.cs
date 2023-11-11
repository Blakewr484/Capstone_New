namespace Capstone.Pages.Data_Classes
{
    public class Event
    {
        public int EventID { get; set; }
        public string? EventName{ get; set; }
        public string? Description{ get; set; }
        public string? Address{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Decimal RegistrationCost { get; set; }
        public string? EventType { get; set; }
        public int EstimatedAttendance { get; set; }
        public string? OrganizerID { get; set; }

        

    }
    
}
