namespace ConsoleAppEntiy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteTuoi : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SinhViens", "Tuoi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "Tuoi", c => c.Int(nullable: false));
        }
    }
}
