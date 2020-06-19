namespace ConsoleAppEntiy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themSDT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "SDT", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "SDT");
        }
    }
}
