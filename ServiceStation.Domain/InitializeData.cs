using ServiceStation.Domain.DAL;
using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;

namespace ServiceStation.Domain
{
    public class InitializeData : System.Data.Entity.DropCreateDatabaseIfModelChanges<ServiceContext>
    {
        protected override void Seed(ServiceContext context)
        {
            var clientCard = new List<ClientCard>
            {
                new ClientCard
                {
                    FirstName = "Fred",
                    LastName = "Durst",
                    Email = "frieddurst@gmail.com",
                    Phone = "+1 904 232 787 11",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("08-20-1970")

                },

                new ClientCard
                {
                    FirstName = "Wes",
                    LastName = "Borland",
                    Email = "wesborland@outlook.com",
                    Phone = "+1 904 400 666 23",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("02-07-1975")

                }
            };
            clientCard.ForEach(s => context.ClientCardsi.Add(s));
            context.SaveChanges();

            var order = new List<Orders>
            {
                new Orders
                {
                    DateStarting = DateTime.Parse("01-09-2015"),
                    DateFinished = DateTime.Parse("03-09-2015"),
                    OrderAmount = 100,
                    Status = OrderStatus.Completed
                },

                new Orders
                {
                    DateStarting = DateTime.Parse("09-15-2016"),
                    DateFinished = DateTime.Parse("10-10-2016"),
                    OrderAmount = 430,
                    Status = OrderStatus.InProgress
                },

                new Orders
                {
                    DateStarting = DateTime.Parse("11-15-2016"),
                    DateFinished = DateTime.Parse("11-18-2016"),
                    OrderAmount = 40,
                    Status = OrderStatus.Canceled
                }
            };
            order.ForEach(s => context.Ordersi.Add(s));
            context.SaveChanges();

            var relatedCar = new List<RelatedCars>
            {
                new RelatedCars
                {
                    Make = "BMW",
                    Model = "320i",
                    Year = "2001",
                    VIN = "1HG CM826 33A 004352"
                },

                new RelatedCars
                {
                    Make = "Volvo",
                    Model = "v40",
                    Year = "1998",
                    VIN = "1HG BH412 5H4 487239"
                },

                new RelatedCars
                {
                    Make = "Mercedes-Benz",
                    Model = "AMG GT",
                    Year = "2016",
                    VIN = "1HG FD189 45G 665189"
                }
            };
            relatedCar.ForEach(s => context.RelatedCarsi.Add(s));
            context.SaveChanges();
        }
    }
}
