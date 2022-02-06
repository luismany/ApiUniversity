namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hoy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inscripcions", "Cursos_Id", "dbo.Cursos");
            DropForeignKey("dbo.Inscripcions", "Docentes_Id", "dbo.Docentes");
            DropForeignKey("dbo.Inscripcions", "Estudiantes_Id", "dbo.Estudiantes");
            DropIndex("dbo.Inscripcions", new[] { "Cursos_Id" });
            DropIndex("dbo.Inscripcions", new[] { "Docentes_Id" });
            DropIndex("dbo.Inscripcions", new[] { "Estudiantes_Id" });
            DropTable("dbo.Inscripcions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        DocenteId = c.Int(nullable: false),
                        Cursos_Id = c.Int(),
                        Docentes_Id = c.Int(),
                        Estudiantes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Inscripcions", "Estudiantes_Id");
            CreateIndex("dbo.Inscripcions", "Docentes_Id");
            CreateIndex("dbo.Inscripcions", "Cursos_Id");
            AddForeignKey("dbo.Inscripcions", "Estudiantes_Id", "dbo.Estudiantes", "Id");
            AddForeignKey("dbo.Inscripcions", "Docentes_Id", "dbo.Docentes", "Id");
            AddForeignKey("dbo.Inscripcions", "Cursos_Id", "dbo.Cursos", "Id");
        }
    }
}
