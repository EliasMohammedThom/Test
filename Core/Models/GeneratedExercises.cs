using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models
{
    public class GeneratedExercises
    {
        public int Id { get; set; }
        public string? Name { get; set; }
      
        public string? Type { get; set; }
        
        public string? Muscle { get; set; }
        
        public string? Equipment { get; set; }
       
        public string? Difficulty { get; set; }

        public string? Instructions { get; set; }

        public string? UserId { get; set; }

    }
}
