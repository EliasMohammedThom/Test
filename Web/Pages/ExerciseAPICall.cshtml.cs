using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;
using Core;
using Newtonsoft.Json;
using Core.Models;

namespace Web.Pages
{
    public class ExerciseAPICallModel : PageModel
    {
       

        [BindProperty]
        public List<Core.Models.ExercisesAPI> Exercises { get; set; }


        public async Task OnGet()
        {
           
           var  response =  APICalls.GetAPICall();
            string result = await response.Result.Content.ReadAsStringAsync();
            List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);
            Exercises  = JsonConvert.DeserializeObject <List<ExercisesAPI>> (result);


        }
    }
}
