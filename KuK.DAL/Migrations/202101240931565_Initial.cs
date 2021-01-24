namespace KuK.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.kukMessages",
                c => new
                    {
                        MessageID = c.Int(nullable: false, identity: true),
                        MessageType = c.Int(nullable: false),
                        Message = c.String(),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MessageID);
            
            CreateTable(
                "dbo.kukNotices",
                c => new
                    {
                        NoticeID = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        kukUser_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.NoticeID)
                .ForeignKey("dbo.kukUsers", t => t.kukUser_UserID)
                .Index(t => t.kukUser_UserID);
            
            CreateTable(
                "dbo.kukUsers",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PassworHash = c.String(),
                        Email = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.kukNotices", "kukUser_UserID", "dbo.kukUsers");
            DropIndex("dbo.kukNotices", new[] { "kukUser_UserID" });
            DropTable("dbo.kukUsers");
            DropTable("dbo.kukNotices");
            DropTable("dbo.kukMessages");
        }
    }
}
