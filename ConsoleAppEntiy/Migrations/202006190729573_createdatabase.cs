namespace ConsoleAppEntiy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lops",
                c => new
                    {
                        IDL = c.Int(nullable: false, identity: true),
                        TenLop = c.String(),
                    })
                .PrimaryKey(t => t.IDL);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        IDSV = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        Tuoi = c.Int(nullable: false),
                        IDL = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDSV)
                .ForeignKey("dbo.Lops", t => t.IDL, cascadeDelete: true)
                .Index(t => t.IDL);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SinhViens", "IDL", "dbo.Lops");
            DropIndex("dbo.SinhViens", new[] { "IDL" });
            DropTable("dbo.SinhViens");
            DropTable("dbo.Lops");
        }
    }
}
