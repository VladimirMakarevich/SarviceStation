using ServiceStation.Domain.Model;
using System;
using System.Collections.Generic;

namespace ServiceStation.Domain.DAL
{
    public class InitializeData : System.Data.Entity.DropCreateDatabaseIfModelChanges<ServiceContext>
    {
        protected override void Seed(ServiceContext context)
        {
            var clientCard = new List<ClientCard>
            {
                new ClientCard
                {
                    ClientId = 1,
                    FirstName = "Fred",
                    LastName = "Durst",
                    Email = "frieddurst@gmail.com",
                    Phone = "+1 904 232 787 11",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("08-20-1970")

                },

                new ClientCard
                {
                    ClientId = 2,
                    FirstName = "Wes",
                    LastName = "Borland",
                    Email = "wesborland@outlook.com",
                    Phone = "+1 904 400 666 23",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("02-07-1975")

                },

                new ClientCard
                {
                    ClientId = 3,
                    FirstName = "John",
                    LastName = "Otto",
                    Email = "johnotto@yandex.ru",
                    Phone = "+1 904 764 786 13",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("03-22-1977")

                },

                new ClientCard
                {
                    ClientId = 4,
                    FirstName = "Sam",
                    LastName = "Rivers",
                    Email = "samrivers@mail.ru",
                    Phone = "+1 904 156 752 32",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("09-02-1977")

                },

                new ClientCard
                {
                    ClientId = 5,
                    FirstName = "DJ",
                    LastName = "Lethal",
                    Email = "djlethal@tut.by",
                    Phone = "+1 904 487 532 45",
                    Address = "Jacksonville, Florida, United State",
                    DateOfBirth = DateTime.Parse("02-18-1972")

                },

                new ClientCard
                {
                    ClientId = 6,
                    FirstName = "Vladimir",
                    LastName = "Makarevich",
                    Email = "business.makarevich@outlook.com",
                    Phone = "+375 29 102 44 85",
                    Address = "Minsk, Republic of Belarus",
                    DateOfBirth = DateTime.Parse("03-13-1992")

                }
            };
            clientCard.ForEach(s => context.ClientCardsi.Add(s));
            context.SaveChanges();

            var relatedCar = new List<RelatedCars>
            {
                new RelatedCars
                {
                    CarId = 1,
                    Make = "BMW",
                    Model = "320i",
                    Year = "2001",
                    VIN = "1HG CM826 33A 004352"
                },

                new RelatedCars
                {
                    CarId = 2,
                    Make = "Volvo",
                    Model = "v40",
                    Year = "1998",
                    VIN = "1HG BH412 5H4 487239"
                },

                new RelatedCars
                {
                    CarId = 3,
                    Make = "Mercedes-Benz",
                    Model = "AMG GT",
                    Year = "2016",
                    VIN = "1HG FD189 45G 665189"
                },

                new RelatedCars
                {
                    CarId = 4,
                    Make = "Yamaha",
                    Model = "Sports Ride",
                    Year = "2015",
                    VIN = "1HG FD756 4G5 456915"
                },

                new RelatedCars
                {
                    CarId = 5,
                    Make = "Honda",
                    Model = "Civic",
                    Year = "2001",
                    VIN = "1HG FGT54 GH5 122647"
                },

                new RelatedCars
                {
                    CarId = 6,
                    Make = "Ford",
                    Model = "Focus",
                    Year = "2012",
                    VIN = "1HG GHG54 JH7 648756"
                }
            };
            relatedCar.ForEach(s => context.RelatedCarsi.Add(s));
            context.SaveChanges();

            var order = new List<Orders>
            {
                new Orders
                {
                    OrderId = 1,
                    Date = DateTime.Parse("01-09-2015"),
                    OrderAmount = 100,
                    Status = OrderStatus.Completed,
                    CarId = 1,
                    ClientId = 1
                },

                new Orders
                {
                    OrderId = 2,
                    Date = DateTime.Parse("09-15-2016"),
                    OrderAmount = 430,
                    Status = OrderStatus.InProgress,
                    CarId = 2,
                    ClientId = 2
                },

                new Orders
                {
                    OrderId = 3,
                    Date = DateTime.Now,
                    OrderAmount = 130,
                    Status = OrderStatus.InProgress,
                    CarId = 3,
                    ClientId = 3
                },

                new Orders
                {
                    OrderId = 4,
                    Date = DateTime.Parse("01-23-2014"),
                    OrderAmount = 40,
                    Status = OrderStatus.Canceled,
                    CarId = 4,
                    ClientId = 4
                },

                new Orders
                {
                    OrderId = 5,
                    Date = DateTime.Parse("12-16-2010"),
                    OrderAmount = 230,
                    Status = OrderStatus.Completed,
                    CarId = 5,
                    ClientId = 5
                },

                new Orders
                {
                    OrderId = 6,
                    Date = DateTime.Parse("10-13-2016"),
                    OrderAmount = 1250,
                    Status = OrderStatus.InProgress,
                    CarId = 4,
                    ClientId = 5
                },

                new Orders
                {
                    OrderId = 7,
                    Date = DateTime.Parse("11-15-2016"),
                    OrderAmount = 405,
                    Status = OrderStatus.InProgress,
                    CarId = 3,
                    ClientId = 5
                }
            };
            order.ForEach(s => context.Ordersi.Add(s));
            context.SaveChanges();
        }
    }
}
