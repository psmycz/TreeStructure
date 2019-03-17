//namespace StrukturaDrzewiasta.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Ver1 : DbMigration
//    {
//        public override void Up()
//        {
//            CreateTable(
//                "dbo.Authors",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Courses",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 255),
//                        Description = c.String(nullable: false, maxLength: 2000),
//                        Level = c.Int(nullable: false),
//                        FullPrice = c.Single(nullable: false),
//                        AuthorId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Authors", t => t.AuthorId)
//                .Index(t => t.AuthorId);
            
//            CreateTable(
//                "dbo.Covers",
//                c => new
//                    {
//                        Id = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Courses", t => t.Id)
//                .Index(t => t.Id);
            
//            CreateTable(
//                "dbo.Tags",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Categories",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(nullable: false, maxLength: 30),
//                        ParentCategoryId = c.Int(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Categories", t => t.ParentCategoryId)
//                .Index(t => t.ParentCategoryId);
            
//            CreateTable(
//                "dbo.CourseTags",
//                c => new
//                    {
//                        CourseId = c.Int(nullable: false),
//                        TagId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => new { t.CourseId, t.TagId })
//                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
//                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
//                .Index(t => t.CourseId)
//                .Index(t => t.TagId);
            
//        }
        
//        public override void Down()
//        {
//            DropForeignKey("dbo.Categories", "ParentCategoryId", "dbo.Categories");
//            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
//            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
//            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
//            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
//            DropIndex("dbo.CourseTags", new[] { "TagId" });
//            DropIndex("dbo.CourseTags", new[] { "CourseId" });
//            DropIndex("dbo.Categories", new[] { "ParentCategoryId" });
//            DropIndex("dbo.Covers", new[] { "Id" });
//            DropIndex("dbo.Courses", new[] { "AuthorId" });
//            DropTable("dbo.CourseTags");
//            DropTable("dbo.Categories");
//            DropTable("dbo.Tags");
//            DropTable("dbo.Covers");
//            DropTable("dbo.Courses");
//            DropTable("dbo.Authors");
//        }
//    }
//}
