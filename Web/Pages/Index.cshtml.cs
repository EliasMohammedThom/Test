using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        //Sonarcloud fix
        public ILogger<IndexModel> Logger => _logger;

        public void OnGet()
        {

           //skall fyllas i eventuellt
        }
    }
}
