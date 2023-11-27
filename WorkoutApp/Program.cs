using Newtonsoft.Json;


namespace WorkoutApp
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            string apiUrl = "https://api.api-ninjas.com/v1/exercises?muscle=biceps";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);

                        foreach (var item in exercises)
                        {
                            Console.WriteLine(item.Name);
                            Console.WriteLine(item.Type);
                            Console.WriteLine(item.Muscle);
                            Console.WriteLine(item.Equipment);
                            Console.WriteLine(item.Difficulty);
                            Console.WriteLine(item.Instructions);
                            Console.WriteLine("-----------------------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Request error: {ex.Message}");
                }
            }
        }





    }
    }
