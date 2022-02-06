namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class midificacionesvarias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras");
            DropIndex("dbo.Cursos", new[] { "CarreraId" });
            AlterColumn("dbo.Cursos", "CarreraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cursos", "CarreraId");
            AddForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras", "Id", cascadeDelete: true);
            DropColumn("dbo.Estudiantes", "FechaMatricula");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "FechaMatricula", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras");
            DropIndex("dbo.Cursos", new[] { "CarreraId" });
            AlterColumn("dbo.Cursos", "CarreraId", c => c.Int());
            CreateIndex("dbo.Cursos", "CarreraId");
            AddForeignKey("dbo.Cursos", "CarreraId", "dbo.Carreras", "Id");
        }
    }
}
