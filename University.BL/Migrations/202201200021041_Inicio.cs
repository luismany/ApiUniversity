namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cursos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Curso = c.String(nullable: false, maxLength: 30),
                        Credito = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Docentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 16),
                        Telefono = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Cedula = c.String(nullable: false, maxLength: 16),
                        Email = c.String(),
                        Telefono = c.Int(nullable: false),
                        FechaMatricula = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Inscripcions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        Cursos_Id = c.Int(),
                        Estudiantes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.Cursos_Id)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiantes_Id)
                .Index(t => t.Cursos_Id)
                .Index(t => t.Estudiantes_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inscripcions", "Estudiantes_Id", "dbo.Estudiantes");
            DropForeignKey("dbo.Inscripcions", "Cursos_Id", "dbo.Cursos");
            DropIndex("dbo.Inscripcions", new[] { "Estudiantes_Id" });
            DropIndex("dbo.Inscripcions", new[] { "Cursos_Id" });
            DropTable("dbo.Inscripcions");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Docentes");
            DropTable("dbo.Cursos");
        }
    }
}
