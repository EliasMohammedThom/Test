using Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class APICalls
    {
        public static async Task<HttpResponseMessage> GetAPICall(string type, string muscle, string difficulty)
        {
            string apiUrl = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}&type={type}&difficulty={difficulty}";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);
                    return response;
                }


                else
                {
                    return response;
                }
            }



        }
    }
}

