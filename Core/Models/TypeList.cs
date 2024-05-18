using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class TypeList
    {
        public string? Name { get; set; }
        public List<FetchedExercises>? Exercises { get; set; }

        public List<Tablevalues> Tablevalues { get; set; } = new List<Tablevalues>();
    }

    public class Tablevalues
    {
        public string Name { get; set; }
        public int Weight { get; set; }
    }
}
