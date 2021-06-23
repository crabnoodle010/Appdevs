namespace ManagerFPTs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentTrainee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentTrainees",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.DepartmentId, t.UserId })
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentTrainees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DepartmentTrainees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.DepartmentTrainees", new[] { "UserId" });
            DropIndex("dbo.DepartmentTrainees", new[] { "DepartmentId" });
            DropTable("dbo.DepartmentTrainees");
        }
    }
}
