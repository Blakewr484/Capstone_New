using Capstone.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Capstone.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private readonly DBClass _dbClass;

        [BindProperty]
        public Events NewEvent { get; set; }

        public CreateEventModel(DBClass dbClass)
        {
            _dbClass = dbClass;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dbClass.InsertEvent(NewEvent);

            return RedirectToPage("/Events/EventApproval");
        }
    }
}
