using System;
using System.Collections.Generic;

namespace ScientistSample.Models
{
    public class ScientistResult
    {
        public Guid ResultId { get; set; }

        public List<Observation> Candidates { get; set; }
        public Dictionary<string, object> Contexts { get; set; }
        public Observation Control { get; set; }
        public string ExperimentName { get; set; }
        public List<Observation> IgnoredObservations { get; set; }
        public bool Matched { get; set; }
        public bool Mismatched { get; set; }
        public List<Observation> MismatchedObservations { get; set; }
        public List<Observation> Observations { get; set; }
    }
}
