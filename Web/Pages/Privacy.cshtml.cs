using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class PrivacyModel : PageModel
    {
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            Logger = logger;
        }

        public ILogger<PrivacyModel> Logger { get; }

        public void OnGet()
        {
            //Not yet implemented
        }
    }
}
