namespace ManagerFPTs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserIfs", "WorkingPlace", c => c.String());
            AddColumn("dbo.UserIfs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserIfs", "Discriminator");
            DropColumn("dbo.UserIfs", "WorkingPlace");
            DropTable("dbo.Departments");
        }
    }
}
