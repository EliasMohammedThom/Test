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

        public List<TableList> TableLists { get; set; } = new List<TableList> ();
    }

    public class Tablevalues
    {
        public int Weight { get; set; }
    }

    public class TableList
    {
        public string ExerciseName { get; set; }
        public List<int> TableValues { get; set; } = new List<int>();
    }
}
