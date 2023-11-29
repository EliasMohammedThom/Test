using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

namespace Web.Pages
{
    public class ExerciseAPICallModel : PageModel
    {
        //private readonly HttpClient _httpClient;

        //public ExerciseAPICallModel(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClient = httpClientFactory.CreateClient();
        //}


        [BindProperty]
        public List<Core.Models.ExercisesAPI> Exercises { get; set; }

        public async Task OnGet()
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = "https://api-ninjas.com/api/exercises?muscle=biceps";
                string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";

                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                try
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string result = await responseMessage.Content.ReadAsStringAsync();
                        Exercises = JsonSerializer.Deserialize<List<Core.Models.ExercisesAPI>>(result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
    }
}
