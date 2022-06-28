namespace ElkaApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Locoation = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobStatus",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        JobID = c.Guid(nullable: false),
                        StatusID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.JobID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.JobID)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        Fullname = c.String(),
                        Brithdate = c.DateTime(nullable: false),
                        Street = c.String(),
                        City = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Profession = c.String(),
                        FilePath = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobStatus", "UserID", "dbo.Users");
            DropForeignKey("dbo.JobStatus", "StatusID", "dbo.Status");
            DropForeignKey("dbo.JobStatus", "JobID", "dbo.Jobs");
            DropIndex("dbo.JobStatus", new[] { "StatusID" });
            DropIndex("dbo.JobStatus", new[] { "JobID" });
            DropIndex("dbo.JobStatus", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Status");
            DropTable("dbo.JobStatus");
            DropTable("dbo.Jobs");
            DropTable("dbo.Companies");
        }
    }
}
