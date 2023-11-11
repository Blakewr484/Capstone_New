using Capstone.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Capstone.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly DBClass _dbClass;
        public List<CreateEventModel> Events { get; set; }

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