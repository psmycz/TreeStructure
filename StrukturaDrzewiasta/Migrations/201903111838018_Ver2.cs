//namespace StrukturaDrzewiasta.Migrations
//{
//    using System;
//    using System.Data.Entity.Migrations;
    
//    public partial class Ver2 : DbMigration
//    {
//        public override void Up()
//        {
//            DropForeignKey("dbo.Courses", "AuthorId", "dbo.Authors");
//            DropForeignKey("dbo.Covers", "Id", "dbo.Courses");
//            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
//            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
//            DropIndex("dbo.Courses", new[] { "AuthorId" });
//            DropIndex("dbo.Covers", new[] { "Id" });
//            DropIndex("dbo.CourseTags", new[] { "CourseId" });
//            DropIndex("dbo.CourseTags", new[] { "TagId" });
//            DropTable("dbo.Authors");
//            DropTable("dbo.Courses");
//            DropTable("dbo.Covers");
//            DropTable("dbo.Tags");
//            DropTable("dbo.CourseTags");
//        }
        
//        public override void Down()
//        {
//            CreateTable(
//                "dbo.CourseTags",
//                c => new
//                    {
//                        CourseId = c.Int(nullable: false),
//                        TagId = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => new { t.CourseId, t.TagId });
            
//            CreateTable(
//                "dbo.Tags",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Covers",
//                c => new
//                    {
//                        Id = c.Int(nullable: false),
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
//                .PrimaryKey(t => t.Id);
            
//            CreateTable(
//                "dbo.Authors",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        Name = c.String(),
//                    })
//                .PrimaryKey(t => t.Id);
            
//            CreateIndex("dbo.CourseTags", "TagId");
//            CreateIndex("dbo.CourseTags", "CourseId");
//            CreateIndex("dbo.Covers", "Id");
//            CreateIndex("dbo.Courses", "AuthorId");
//            AddForeignKey("dbo.CourseTags", "TagId", "dbo.Tags", "Id", cascadeDelete: true);
//            AddForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
//            AddForeignKey("dbo.Covers", "Id", "dbo.Courses", "Id");
//            AddForeignKey("dbo.Courses", "AuthorId", "dbo.Authors", "Id");
//        }
//    }
//}
