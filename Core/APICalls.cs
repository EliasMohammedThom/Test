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
        public static async Task<HttpResponseMessage> GetAPICall()
        {
            string apiUrl = "https://api.api-ninjas.com/v1/exercises?muscle=biceps";
            string apiKey = "7XGUZFPA48mkJTnWL2ZRuA==DyuL7vMFbtzbJHYg";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
               
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        List<ExercisesAPI> exercises = JsonConvert.DeserializeObject<List<ExercisesAPI>>(result);
                        //foreach (var item in exercises)
                        //{
                        //    Console.WriteLine(item.Name);
                        //    Console.WriteLine(item.Type);
                        //    Console.WriteLine(item.Muscle);
                        //    Console.WriteLine(item.Equipment);
                        //    Console.WriteLine(item.Difficulty);
                        //    Console.WriteLine(item.Instructions);
                        //    Console.WriteLine("-----------------------------------------------");
                        //}
                        return response;
                    }
                    

                    else
                    {
                        //Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return response;
                    }
                }
               

               
            }
        }
    }

