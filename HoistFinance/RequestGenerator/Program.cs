using Bogus;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;

namespace RequestGenerator
{
    using HoistFinance.Contract.Models;
    using System.Collections.Generic;

    internal class Program
    {
        private static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Enter a numeric value:");
                return 1;
            }
            int numberInserted;
            var isParsed = int.TryParse(args[0], out numberInserted);
            if (!isParsed)
            {
                Console.WriteLine("Enter a valid number:");
                return 1;
            }
            var baseUri = ConfigurationManager.AppSettings["RequestApi"];
            using (var client = new WebClient())
            {
                client.BaseAddress = baseUri;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var json = GetGeneratedDataToJson(numberInserted);
                var res = client.UploadString("api/data/", json);
                Console.WriteLine("Done! " + res.ToString());
                return 0;
            }
        }

        private static string GetGeneratedDataToJson(int numberInserted)
        {
            object requests = new List<object>();

            var requestsList = new Faker<RequestModel>().RuleFor(r => r.Index, f => f.IndexFaker)
                    .RuleFor(r => r.Name, f => f.Name.FirstName())
                    .RuleFor(r => r.Visits, f => f.Random.Number(0, 100))
                    .RuleFor(r => r.Date, f => f.Date.Future());
            requests = requestsList.Generate(numberInserted);

            return JsonConvert.SerializeObject(requests, Formatting.Indented);
        }
    }
}

