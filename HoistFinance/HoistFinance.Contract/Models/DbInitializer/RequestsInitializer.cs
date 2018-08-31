using System.Collections.Generic;

namespace HoistFinance.Contract
{
    using HoistFinance.Contract.Models;
    using System;
    using System.Data.Entity;

    public class RequestsInitializer : DropCreateDatabaseAlways<RequestsContext>
    {
        protected override void Seed(RequestsContext context)
        {
            base.Seed(context);

            //Create some photos
            var photos = new List<RequestModel>
            {
                new RequestModel {
                    Visits = 1,
                    Name = "Bogdan",
                    Date = DateTime.Now
                },
                new RequestModel {
                    Visits = 3,
                    Name = "Bogdan",
                    Date = DateTime.Now.AddDays(5)
                },
                new RequestModel {
                    Name = "Bogdan",
                    Date = DateTime.Now.AddDays(5)
                }
            };
            photos.ForEach(s => context.Requests.Add(s));
            context.SaveChanges();
        }
    }
}