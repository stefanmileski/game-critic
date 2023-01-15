namespace Proekt_IT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModel4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "UserEmail");
        }
    }
}
