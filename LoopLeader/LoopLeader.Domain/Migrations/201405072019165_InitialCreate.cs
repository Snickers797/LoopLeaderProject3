namespace LoopLeader.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.String(nullable: false, maxLength: 128),
                        CurrentText = c.String(),
                        NewText = c.String(),
                    })
                .PrimaryKey(t => t.ContentID);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false, maxLength: 25),
                        Password = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        StreetAddress1 = c.String(maxLength: 100),
                        StreetAddress2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Zip = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MemberId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InStock = c.Boolean(nullable: false),
                        Shipping = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Members");
            DropTable("dbo.Contents");
        }
    }
}
