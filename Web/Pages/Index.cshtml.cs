using Core.Interfaces.ModelServices;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IScheduleService _scheduleService;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(IScheduleService scheduleService, UserManager<IdentityUser> userManager)
        {
            _scheduleService = scheduleService;
            _userManager = userManager;
        }
        public void OnGet()
        {

          //Not yet implemented
        }
        public async Task<IActionResult> OnPost() 
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);
            var singledSchedule = _scheduleService.GetAllSchedules().Where(X => X.UserId == identityUser.Id).ToList();

            if (singledSchedule.Count == 0)             
            {
                Schedule schedule = new Schedule { UserId = identityUser.Id };
                _scheduleService.AddSchedule(schedule);
            }
          


            return Redirect("/EditSchedule");
        }
    }
}
