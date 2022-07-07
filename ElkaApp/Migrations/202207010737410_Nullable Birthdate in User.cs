namespace ElkaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableBirthdateinUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Brithdate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Brithdate", c => c.DateTime(nullable: false));
        }
    }
}
