namespace ConsoleAppEntiy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteSDT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lops", "Lop_IDL", c => c.Int());
            CreateIndex("dbo.Lops", "Lop_IDL");
            AddForeignKey("dbo.Lops", "Lop_IDL", "dbo.Lops", "IDL");
            DropColumn("dbo.SinhViens", "SDT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SinhViens", "SDT", c => c.String(maxLength: 20));
            DropForeignKey("dbo.Lops", "Lop_IDL", "dbo.Lops");
            DropIndex("dbo.Lops", new[] { "Lop_IDL" });
            DropColumn("dbo.Lops", "Lop_IDL");
        }
    }
}
