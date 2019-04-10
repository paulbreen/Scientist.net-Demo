using System.Linq;
using System.Threading.Tasks;
using GitHub;
using Newtonsoft.Json;

namespace ScientistSample.Models
{
    public class ResultPublisher : IResultPublisher
    {
        public ScientistResult Result;

        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            // This is a comment
            Result = new ScientistResult
            {
                ExperimentName = result.ExperimentName,
                Matched = result.Matched,
            };

            Result.Candidates = result.Candidates.Select(
                o => new Observation
                {
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = JsonConvert.SerializeObject(o.Value)
                }).ToList();

            Result.Contexts = result.Contexts.ToDictionary(resultContext => resultContext.Key,
                resultContext => resultContext.Value);

            Result.Control = new Observation
            {
                Duration = result.Control.Duration,
                Exception = result.Control.Exception,
                Name = result.Control.Name,
                Thrown = result.Control.Thrown,
                Value = JsonConvert.SerializeObject(result.Control.Value)
            };

            Result.IgnoredObservations = result.IgnoredObservations.Select(
                o => new Observation
                {
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = JsonConvert.SerializeObject(o.Value)
                }).ToList();

            Result.MismatchedObservations = result.MismatchedObservations.Select(
                o => new Observation
                {
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = JsonConvert.SerializeObject(o.Value)
                }).ToList();

            Result.Observations = result.Observations.Select(
                o => new Observation
                {
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = JsonConvert.SerializeObject(o.Value)
                }).ToList();

            return Task.FromResult(0);
        }
    }
}
