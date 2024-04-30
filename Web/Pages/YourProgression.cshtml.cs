using Core.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class YourProgressionModel : PageModel
    {
        ApplicationDbContext ApplicationDbContext { get; set; }
        public List<Workout> Workouts { get; set; }
        public YourProgressionModel(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;

        }


        public void OnGet()
        {

        }
    }
}
