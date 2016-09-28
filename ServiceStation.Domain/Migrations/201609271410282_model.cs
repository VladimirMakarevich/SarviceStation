namespace ServiceStation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            AddColumn("service.RelatedCars", "Models", c => c.String(nullable: false));
            DropColumn("service.RelatedCars", "Model");
        }
        
        public override void Down()
        {
            AddColumn("service.RelatedCars", "Model", c => c.String(nullable: false));
            DropColumn("service.RelatedCars", "Models");
        }
    }
}
