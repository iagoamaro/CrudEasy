namespace CrudEasy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emaol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pessoa", "email", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pessoa", "email");
        }
    }
}
