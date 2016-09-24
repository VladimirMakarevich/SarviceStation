using ServiceStation.Domain.DAL;
using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    DateOfBirth = "1970-20-08"

                },

                new ClientCard
                {
                    FirstName = "Wes",
                    LastName = "Borland",
                    Email = "wesborland@outlook.com",
                    Phone = "+1 904 400 666 23",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = "1975-7-02"

                }
            };
            clientCard.ForEach(s => context.ClientCardsi.Add(s));
            context.SaveChanges();

            var order = new List<Orders>
            {
                new Orders
                {
                    Date = DateTime.Now,
                    OrderAmount = 100,
                    Status = OrderStatus.Completed
                },

                new Orders
                {
                    Date = DateTime.Now,
                    OrderAmount = 430,
                    Status = OrderStatus.InProgress
                },

                new Orders
                {
                    Date = DateTime.Now,
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
