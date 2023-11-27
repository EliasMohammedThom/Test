using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Models
{
    [Keyless]
    public class Nutrition
    {
        public Nutrition() { }

        
            [JsonPropertyName("name")]
        
            public string Name { get; set; }
            [JsonPropertyName("calories")]
            public float Calories { get; set; }
            [JsonPropertyName("serving_size_g")]
            public float ServingSizePerGram { get; set; }
            [JsonPropertyName("fat_total_g")]
            public float FatTotalGram { get; set; }
            [JsonPropertyName("fat_saturated_g")]
            public float SaturatedGram { get; set; }
            [JsonPropertyName("protein_g")]
            public float ProteinGram { get; set; }
            [JsonPropertyName("sodium_mg")]
            public float SodiumMilligram { get; set; }
            [JsonPropertyName("potassium_mg")]
            public float PotassiumMilligram { get; set; }
            [JsonPropertyName("cholesterol_mg")]
            public float Cholesterol { get; set; }
            [JsonPropertyName("carbohydrates_total_g")]
            public float CarbohydratesPerGram { get; set; }
            [JsonPropertyName("fiber_g")]
            public float FiberPerGram { get; set; }
            [JsonPropertyName("sugar_g")]
            public float Sugar { get; set; }
        }
}
