namespace ServiceStation.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NLogRemove : DbMigration
    {
        public override void Up()
        {
            DropTable("logger.NLog");
        }
        
        public override void Down()
        {
            CreateTable(
                "logger.NLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventDateTime = c.DateTime(nullable: false),
                        EventLevel = c.String(nullable: false),
                        UserName = c.String(nullable: false),
                        MachineName = c.String(nullable: false),
                        EventMessage = c.String(nullable: false),
                        ErrorSource = c.String(nullable: false),
                        ErrorClass = c.String(),
                        ErrorMethod = c.String(),
                        ErrorMessage = c.String(),
                        InnerErrorMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
