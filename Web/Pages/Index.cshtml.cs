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

        public bool IsScheduleNull => Schedule == null;
        public string ScheduleClass => IsScheduleNull ? " disabled-link" : "";

        [BindProperty]
        public Schedule? Schedule { get; set; }

        public IndexModel(IScheduleService scheduleService, UserManager<IdentityUser>? userManager)
        {
            _scheduleService = scheduleService;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);
            if (identityUser != null)
            {
                Schedule = _scheduleService.GetScheduleByUserId(identityUser.Id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            IdentityUser? identityUser = await _userManager.GetUserAsync(User);

            Schedule? singledSchedule = _scheduleService.GetScheduleByUserId(identityUser.Id);

            if (singledSchedule is null)
            {
                Schedule schedule = new()
                {
                    UserId = identityUser.Id,
                };
                _scheduleService.AddSchedule(schedule);
            }
            return Redirect("/EditSchedule");
        }
    }
}
