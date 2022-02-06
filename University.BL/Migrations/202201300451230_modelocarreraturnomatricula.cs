namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelocarreraturnomatricula : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carreras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCarrera = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInscripcion = c.DateTime(nullable: false),
                        EstudianteId = c.Int(nullable: false),
                        CarreraId = c.Int(nullable: false),
                        TurnoId = c.Int(nullable: false),
                        Carreras_Id = c.Int(),
                        Estudiantes_Id = c.Int(),
                        Turnos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carreras", t => t.Carreras_Id)
                .ForeignKey("dbo.Estudiantes", t => t.Estudiantes_Id)
                .ForeignKey("dbo.Turnos", t => t.Turnos_Id)
                .Index(t => t.Carreras_Id)
                .Index(t => t.Estudiantes_Id)
                .Index(t => t.Turnos_Id);
            
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Turno = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cursos", "CarreraId", c => c.Int());
            AddColumn("dbo.Cursos", "Carreras_Id", c => c.Int());
            CreateIndex("dbo.Cursos", "Carreras_Id");
            AddForeignKey("dbo.Cursos", "Carreras_Id", "dbo.Carreras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "Turnos_Id", "dbo.Turnos");
            DropForeignKey("dbo.Matriculas", "Estudiantes_Id", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "Carreras_Id", "dbo.Carreras");
            DropForeignKey("dbo.Cursos", "Carreras_Id", "dbo.Carreras");
            DropIndex("dbo.Matriculas", new[] { "Turnos_Id" });
            DropIndex("dbo.Matriculas", new[] { "Estudiantes_Id" });
            DropIndex("dbo.Matriculas", new[] { "Carreras_Id" });
            DropIndex("dbo.Cursos", new[] { "Carreras_Id" });
            DropColumn("dbo.Cursos", "Carreras_Id");
            DropColumn("dbo.Cursos", "CarreraId");
            DropTable("dbo.Turnos");
            DropTable("dbo.Matriculas");
            DropTable("dbo.Carreras");
        }
    }
}
