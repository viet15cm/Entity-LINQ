namespace ConsoleAppEntiy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemCot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "Tuoi", c => c.Int(nullable: false));
            AddColumn("dbo.SinhViens", "SDT", c => c.String(maxLength: 10));
            AlterColumn("dbo.Lops", "TenLop", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.SinhViens", "Ten", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SinhViens", "Ten", c => c.String());
            AlterColumn("dbo.Lops", "TenLop", c => c.String());
            DropColumn("dbo.SinhViens", "SDT");
            DropColumn("dbo.SinhViens", "Tuoi");
        }
    }
}
