namespace CrudEasy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pessoa",
                c => new
                    {
                        pessoaId = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 20),
                        endereco = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.pessoaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.pessoa");
        }
    }
}
