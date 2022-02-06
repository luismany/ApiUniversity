namespace University.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablaInscripcionModificada : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inscripcions", "DocenteId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inscripcions", "DocenteId", c => c.Int());
        }
    }
}
