namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class corrigiendoloanterior : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matriculas", "Carreras_Id", "dbo.Carreras");
            DropForeignKey("dbo.Matriculas", "Estudiantes_Id", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "Turnos_Id", "dbo.Turnos");
            DropIndex("dbo.Matriculas", new[] { "Carreras_Id" });
            DropIndex("dbo.Matriculas", new[] { "Estudiantes_Id" });
            DropIndex("dbo.Matriculas", new[] { "Turnos_Id" });
            DropColumn("dbo.Matriculas", "CarreraId");
            DropColumn("dbo.Matriculas", "EstudianteId");
            DropColumn("dbo.Matriculas", "TurnoId");
            RenameColumn(table: "dbo.Matriculas", name: "Carreras_Id", newName: "CarreraId");
            RenameColumn(table: "dbo.Matriculas", name: "Estudiantes_Id", newName: "EstudianteId");
            RenameColumn(table: "dbo.Matriculas", name: "Turnos_Id", newName: "TurnoId");
            AlterColumn("dbo.Matriculas", "CarreraId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matriculas", "EstudianteId", c => c.Int(nullable: false));
            AlterColumn("dbo.Matriculas", "TurnoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matriculas", "EstudianteId");
            CreateIndex("dbo.Matriculas", "CarreraId");
            CreateIndex("dbo.Matriculas", "TurnoId");
            AddForeignKey("dbo.Matriculas", "CarreraId", "dbo.Carreras", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matriculas", "TurnoId", "dbo.Turnos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "TurnoId", "dbo.Turnos");
            DropForeignKey("dbo.Matriculas", "EstudianteId", "dbo.Estudiantes");
            DropForeignKey("dbo.Matriculas", "CarreraId", "dbo.Carreras");
            DropIndex("dbo.Matriculas", new[] { "TurnoId" });
            DropIndex("dbo.Matriculas", new[] { "CarreraId" });
            DropIndex("dbo.Matriculas", new[] { "EstudianteId" });
            AlterColumn("dbo.Matriculas", "TurnoId", c => c.Int());
            AlterColumn("dbo.Matriculas", "EstudianteId", c => c.Int());
            AlterColumn("dbo.Matriculas", "CarreraId", c => c.Int());
            RenameColumn(table: "dbo.Matriculas", name: "TurnoId", newName: "Turnos_Id");
            RenameColumn(table: "dbo.Matriculas", name: "EstudianteId", newName: "Estudiantes_Id");
            RenameColumn(table: "dbo.Matriculas", name: "CarreraId", newName: "Carreras_Id");
            AddColumn("dbo.Matriculas", "TurnoId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "EstudianteId", c => c.Int(nullable: false));
            AddColumn("dbo.Matriculas", "CarreraId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matriculas", "Turnos_Id");
            CreateIndex("dbo.Matriculas", "Estudiantes_Id");
            CreateIndex("dbo.Matriculas", "Carreras_Id");
            AddForeignKey("dbo.Matriculas", "Turnos_Id", "dbo.Turnos", "Id");
            AddForeignKey("dbo.Matriculas", "Estudiantes_Id", "dbo.Estudiantes", "Id");
            AddForeignKey("dbo.Matriculas", "Carreras_Id", "dbo.Carreras", "Id");
        }
    }
}
