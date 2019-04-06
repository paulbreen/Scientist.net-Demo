using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScientistSample.Models
{
    public class Observation
    {
        public object CleanedValue { get; set; }
        public TimeSpan Duration { get; set; }
        public Exception Exception { get; set; }
        public string Name { get; set; }
        public bool Thrown { get; set; }
        public object Value { get; set; }
    }
}
