namespace ServiceStation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rebuild_db : DbMigration
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
                "service.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        OrderAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("service.RelatedCars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("service.ClientCard", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.CarId);
            
            CreateTable(
                "service.RelatedCars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Make = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        VIN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("service.Orders", "ClientId", "service.ClientCard");
            DropForeignKey("service.Orders", "CarId", "service.RelatedCars");
            DropIndex("service.Orders", new[] { "CarId" });
            DropIndex("service.Orders", new[] { "ClientId" });
            DropTable("service.RelatedCars");
            DropTable("service.Orders");
            DropTable("service.ClientCard");
        }
    }
}
