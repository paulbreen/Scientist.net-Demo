using System.Linq;
using System.Threading.Tasks;
using GitHub;

namespace ScientistSample.Models
{
    public class ResultPublisher : IResultPublisher
    {
        public ScientistResult Result;

        public Task Publish<T, TClean>(Result<T, TClean> result)
        {
            Result = new ScientistResult
            {
                ExperimentName = result.ExperimentName,
                Matched = result.Matched,
                Mismatched = result.Mismatched
            };

            Result.Candidates = result.Candidates.Select(
                o => new Observation
                {
                    CleanedValue = o.CleanedValue,
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = o.Value
                }).ToList();

            Result.Contexts = result.Contexts.ToDictionary(resultContext => resultContext.Key,
                resultContext => resultContext.Value);

            Result.Control = new Observation
            {
                CleanedValue = result.Control.CleanedValue,
                Duration = result.Control.Duration,
                Exception = result.Control.Exception,
                Name = result.Control.Name,
                Thrown = result.Control.Thrown,
                Value = result.Control.Value
            };

            Result.IgnoredObservations = result.IgnoredObservations.Select(
                o => new Observation
                {
                    CleanedValue = o.CleanedValue,
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = o.Value
                }).ToList();

            Result.MismatchedObservations = result.MismatchedObservations.Select(
                o => new Observation
                {
                    CleanedValue = o.CleanedValue,
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = o.Value
                }).ToList();

            Result.Observations = result.Observations.Select(
                o => new Observation
                {
                    CleanedValue = o.CleanedValue,
                    Duration = o.Duration,
                    Exception = o.Exception,
                    Name = o.Name,
                    Thrown = o.Thrown,
                    Value = o.Value
                }).ToList();

            return Task.FromResult(0);
        }
    }
}
