using Capstone.Pages.Data_Classes;
using Capstone.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Capstone.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly DBClass _dbClass;
        public List<Event> Events { get; set; }

        public IndexModel(DBClass dbClass)
        {
            _dbClass = dbClass;
        }

        public void OnGet()
        {
            Events = _dbClass.GetAllEvents();
        }
    }
}
