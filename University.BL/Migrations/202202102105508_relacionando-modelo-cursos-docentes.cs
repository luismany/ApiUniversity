namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relacionandomodelocursosdocentes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cursos", "DocenteId", c => c.Int());
            CreateIndex("dbo.Cursos", "DocenteId");
            AddForeignKey("dbo.Cursos", "DocenteId", "dbo.Docentes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursos", "DocenteId", "dbo.Docentes");
            DropIndex("dbo.Cursos", new[] { "DocenteId" });
            DropColumn("dbo.Cursos", "DocenteId");
        }
    }
}
