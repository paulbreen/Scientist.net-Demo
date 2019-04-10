using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common;
using GitHub;
using ScientistSample.Models;

namespace ScientistSample.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            ((ResultPublisher)Scientist.ResultPublisher).Result = null;
            Scientist.Enabled(() => true);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Simple()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Simple([Required] string numbers)
        {
            if (!ModelState.IsValid) return View(numbers);

            var list = new List<int>();

            foreach (var n in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(n, out var result))
                {
                    list.Add(result);
                }
            }

            var resultSummary = Scientist.Science<Result>("Simple Example", experiment =>
            {
                experiment.Compare((x,y) => x.Largest == y.Largest && Math.Abs(x.Average - y.Average) < .5 && x.Smallest == y.Smallest && x.Sum == y.Sum );
                experiment.Use( ()  => OldApi.Math.Summary(list.ToArray()));
                experiment.Try( () => NewApi.Math.Summary(list.ToArray()));
            });

            ViewData.Add("Result", ((ResultPublisher)Scientist.ResultPublisher).Result);

            return View(resultSummary);
        }


        [HttpGet]
        public IActionResult Exception()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Exception([Required] string numbers)
        {
            if (!ModelState.IsValid) return View(numbers);

            var list = new List<int>();

            foreach (var n in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(n, out var result))
                {
                    list.Add(result);
                }
            }

            var resultSummary = Scientist.Science<Result>("Math", experiment =>
            {
                experiment.Compare((x, y) => x.Largest == y.Largest && Math.Abs(x.Average - y.Average) < .5 && x.Smallest == y.Smallest && x.Sum == y.Sum);
                experiment.Use(() => OldApi.Math.Summary(list.ToArray()));
                experiment.Try(() => throw new Exception("Oh Oh Spaghettios"));
            });

            ViewData.Add("Result", ((ResultPublisher)Scientist.ResultPublisher).Result);

            return View(resultSummary);
        }

        [HttpGet]
        public IActionResult Random()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Random([Required] string numbers)
        {
            if (!ModelState.IsValid) return View(numbers);

            var list = new List<int>();

            foreach (var n in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(n, out var result))
                {
                    list.Add(result);
                }
            }

            Scientist.Enabled(() => DateTime.Now.Millisecond % 2 == 0);

            var resultSummary = Scientist.Science<Result>("Math", experiment =>
            {
                experiment.Compare((x, y) => x.Largest == y.Largest && Math.Abs(x.Average - y.Average) < .5 && x.Smallest == y.Smallest && x.Sum == y.Sum);
                experiment.Use(() => OldApi.Math.Summary(list.ToArray()));
                experiment.Try(() => NewApi.Math.Summary(list.ToArray()));
            });

            ViewData.Add("Result", ((ResultPublisher)Scientist.ResultPublisher).Result);

            return View(resultSummary);
        }

        [HttpGet]
        public IActionResult MultipleCandidates()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult MultipleCandidates([Required] string numbers)
        {
            if (!ModelState.IsValid) return View(numbers);

            var list = new List<int>();

            foreach (var n in numbers.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(n, out var result))
                {
                    list.Add(result);
                }
            }

            var resultSummary = Scientist.Science<Result>("Math", experiment =>
            {
                experiment.Compare((x, y) => x.Largest == y.Largest && Math.Abs(x.Average - y.Average) < .5 && x.Smallest == y.Smallest && x.Sum == y.Sum);
                experiment.Use(() => OldApi.Math.Summary(list.ToArray()));
                experiment.Try("Candidate 1", () => NewApi.Math.Summary(list.ToArray()));
                experiment.Try("Candidate 2", () => NewApi.Math.Summary(list.ToArray()));
            });

            ViewData.Add("Result", ((ResultPublisher)Scientist.ResultPublisher).Result);

            return View(resultSummary);
        }

        [HttpGet]
        public IActionResult Advanced()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}