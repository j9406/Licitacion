namespace PCILicitacion.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId", "dbo.LicitacionPartidaProducto");
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionPartidaProductoId" });
            DropColumn("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId", c => c.Long(nullable: false));
            CreateIndex("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId");
            AddForeignKey("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId", "dbo.LicitacionPartidaProducto", "Id");
        }
    }
}
