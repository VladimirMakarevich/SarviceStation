namespace ServiceStation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "service.ClientCard",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "service.RelatedCars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                        ClientCard_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("service.ClientCard", t => t.ClientCard_ClientId)
                .Index(t => t.ClientCard_ClientId);
            
            CreateTable(
                "service.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        DateStarting = c.DateTime(nullable: false),
                        DateFinished = c.DateTime(nullable: false),
                        OrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        Cars_CarId = c.Int(),
                        Clients_ClientId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("service.RelatedCars", t => t.Cars_CarId)
                .ForeignKey("service.ClientCard", t => t.Clients_ClientId)
                .Index(t => t.Cars_CarId)
                .Index(t => t.Clients_ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("service.RelatedCars", "ClientCard_ClientId", "service.ClientCard");
            DropForeignKey("service.Orders", "Clients_ClientId", "service.ClientCard");
            DropForeignKey("service.Orders", "Cars_CarId", "service.RelatedCars");
            DropIndex("service.Orders", new[] { "Clients_ClientId" });
            DropIndex("service.Orders", new[] { "Cars_CarId" });
            DropIndex("service.RelatedCars", new[] { "ClientCard_ClientId" });
            DropTable("service.Orders");
            DropTable("service.RelatedCars");
            DropTable("service.ClientCard");
        }
    }
}
