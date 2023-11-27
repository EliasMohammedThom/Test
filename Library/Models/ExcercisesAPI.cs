﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ExercisesAPI
    {

        [Key]
        public int Id { get; set; }

        public Workout Workout { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("muscle")]
        public string Muscle { get; set; }
        [JsonPropertyName("equipment")]
        public string Equipment { get; set; }
        [JsonPropertyName("difficulty")]
        public string Difficulty { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }
    }
}
