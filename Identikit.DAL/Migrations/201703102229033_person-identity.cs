namespace Identikit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class personidentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonIdentities",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Name = c.String(nullable: false, maxLength: 50), 
                    Surname = c.String(nullable: false, maxLength: 50),
                    Lastname = c.String(nullable: false, maxLength: 50),
                    Height = c.Double(nullable: false),
                    Hair = c.Int(nullable: false),
                    Eye = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonIdentities");
        }
    }
}
