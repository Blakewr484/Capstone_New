namespace Capstone.Pages.Data_Classes
{
    public class SubEvent
    {
        public int SubEventID { get; set; }
        public string? SubEventName { get; set; }
        public string? Description { get; set; }
        public string? SubEventType { get; set; }
        public int EstimatedAttendance { get; set; }
        public int EventID { get; set; }
        public int HostID { get; set; }

    }
}
