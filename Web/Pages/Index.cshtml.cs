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
        private readonly UserManager<IdentityUser>? _userManager;

        [BindProperty] 
        public Schedule? Schedule { get; set; }

        public IndexModel(IScheduleService scheduleService, UserManager<IdentityUser>? userManager)
        {
            _scheduleService = scheduleService;
            _userManager = userManager;
        }

        public async Task <IActionResult> OnGetAsync()
        {
            //Not yet implemented
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);
            if(identityUser != null)
            {
                Schedule = _scheduleService.GetScheduleByUserId(identityUser.Id);
            }
          
            return Page();
        }

        public async Task<IActionResult> OnPost() 
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            var singledSchedule = _scheduleService.GetScheduleByUserId(identityUser.Id);

            if (singledSchedule is null)
            {
                Schedule schedule = new Schedule
                {
                   UserId = identityUser.Id,
                };
                _scheduleService.AddSchedule(schedule);
            }
            return Redirect("/EditSchedule");
        }
    }
}
