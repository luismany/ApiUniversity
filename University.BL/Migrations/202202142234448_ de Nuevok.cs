namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deNuevok : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EncuentrosCuatrimestres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cuatrimestre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RegularCuatrimestres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cuatrimestre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Cursos", "RegularCuatrimestreId", c => c.Int());
            AddColumn("dbo.Cursos", "EncuentrosCuatrimestreId", c => c.Int());
            AlterColumn("dbo.Cursos", "Curso", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Cursos", "RegularCuatrimestreId");
            CreateIndex("dbo.Cursos", "EncuentrosCuatrimestreId");
            AddForeignKey("dbo.Cursos", "EncuentrosCuatrimestreId", "dbo.EncuentrosCuatrimestres", "Id");
            AddForeignKey("dbo.Cursos", "RegularCuatrimestreId", "dbo.RegularCuatrimestres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cursos", "RegularCuatrimestreId", "dbo.RegularCuatrimestres");
            DropForeignKey("dbo.Cursos", "EncuentrosCuatrimestreId", "dbo.EncuentrosCuatrimestres");
            DropIndex("dbo.Cursos", new[] { "EncuentrosCuatrimestreId" });
            DropIndex("dbo.Cursos", new[] { "RegularCuatrimestreId" });
            AlterColumn("dbo.Cursos", "Curso", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Cursos", "EncuentrosCuatrimestreId");
            DropColumn("dbo.Cursos", "RegularCuatrimestreId");
            DropTable("dbo.RegularCuatrimestres");
            DropTable("dbo.EncuentrosCuatrimestres");
        }
    }
}
