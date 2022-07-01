namespace ElkaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPathFileinCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Companies", "FilePath");
        }
    }
}
