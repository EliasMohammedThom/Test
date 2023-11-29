using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        ////Sonarcloud fix
        //public ILogger<IndexModel> Logger => _logger;
        private readonly IScheduleService _scheduleService;

        public IndexModel(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        public void OnGet()
        {

          
        }
        public void OnPost(int userId) 
        {

            Schedule schedule = new Schedule { UserId = userId };

            _scheduleService.AddSchedule(schedule);
        }
        public void CreateSchedule()
        {


        }
    }
}
