using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class FetchedExercises
    {

        [Key]
        public int Id { get; set; }
        public int? WorkoutId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("muscle")]
        public string? Muscle { get; set; }
        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }
        [JsonPropertyName("difficulty")]
        public string? Difficulty { get; set; }
        [JsonPropertyName("instructions")]
        public string? Instructions { get; set; }
        public int? Sets { get; set; }
        public int? Repetitions { get; set; }
        public bool? Generated { get; set; }
        public string? UserId { get; set; }
        public int? Weight { get; set; }
        public float? Distance { get; set; }
        public DateTime? Time { get; set; }
    }
}
