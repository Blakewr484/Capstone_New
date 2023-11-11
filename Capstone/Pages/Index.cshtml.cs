using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Capstone.Pages
{
    public class IndexModel : PageModel
    {
        public string HomePageUrl { get; } = "/Index";
        public string EventsPageUrl { get; } = "/Events";
        public string CalendarPageUrl { get; } = "/Calendar";
        public string MySchedulePageUrl { get; } = "/MySchedule";
        public string ProfilePageUrl { get; } = "/Profile";
        public string SettingsPageUrl { get; } = "/Settings";

        public void OnGet()
        {
        }
    }
}