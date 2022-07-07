namespace ElkaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Location", c => c.String());
            DropColumn("dbo.Jobs", "Locoation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "Locoation", c => c.String());
            DropColumn("dbo.Jobs", "Location");
        }
    }
}
