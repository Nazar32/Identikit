namespace Identikit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                {
                    Id = c.Guid(nullable: false),
                    Login = c.String(nullable: false, maxLength: 50),
                    Password = c.String(nullable: false, maxLength: 50),
                    Name = c.String(nullable: false, maxLength: 50),
                    IsAdmin = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);   
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
