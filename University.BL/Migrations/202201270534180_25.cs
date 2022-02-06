namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inscripcions", "DocenteId", c => c.Int());
            AddColumn("dbo.Inscripcions", "Docentes_Id", c => c.Int());
            CreateIndex("dbo.Inscripcions", "Docentes_Id");
            AddForeignKey("dbo.Inscripcions", "Docentes_Id", "dbo.Docentes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcions", "Docentes_Id", "dbo.Docentes");
            DropIndex("dbo.Inscripcions", new[] { "Docentes_Id" });
            DropColumn("dbo.Inscripcions", "Docentes_Id");
            DropColumn("dbo.Inscripcions", "DocenteId");
        }
    }
}
