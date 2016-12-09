namespace PCILicitacion.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Licitacion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitadorId = c.Long(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        FechaAdjudicacion = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licitador", t => t.LicitadorId)
                .Index(t => t.LicitadorId);
            
            CreateTable(
                "dbo.LicitacionOferta",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionId = c.Long(nullable: false),
                        LicitanteId = c.Long(nullable: false),
                        FechaOferta = c.DateTime(nullable: false),
                        FechaVigencia = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licitante", t => t.LicitanteId)
                .ForeignKey("dbo.Licitacion", t => t.LicitacionId)
                .Index(t => t.LicitacionId)
                .Index(t => t.LicitanteId);
            
            CreateTable(
                "dbo.LicitacionPartidas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionId = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .ForeignKey("dbo.Licitacion", t => t.LicitacionId)
                .Index(t => t.LicitacionId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.LicitacionPartidaMarcas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionPartidaId = c.Long(nullable: false),
                        ProductoMarcaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductoMarca", t => t.ProductoMarcaId)
                .ForeignKey("dbo.LicitacionPartidas", t => t.LicitacionPartidaId)
                .Index(t => t.LicitacionPartidaId)
                .Index(t => t.ProductoMarcaId);
            
            CreateTable(
                "dbo.ProductoMarca",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductoMarcas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProductoId = c.Long(nullable: false),
                        ProductoMarcaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductoMarca", t => t.ProductoMarcaId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.ProductoMarcaId);
            
            CreateTable(
                "dbo.LicitacionOfertaPartida",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionOfertaId = c.Long(nullable: false),
                        LicitacionPartidaId = c.Long(nullable: false),
                        ProductoMarcaId = c.Long(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicitacionOferta", t => t.LicitacionOfertaId)
                .ForeignKey("dbo.LicitacionPartidas", t => t.LicitacionPartidaId)
                .ForeignKey("dbo.ProductoMarca", t => t.ProductoMarcaId)
                .Index(t => t.LicitacionOfertaId)
                .Index(t => t.LicitacionPartidaId)
                .Index(t => t.ProductoMarcaId);
            
            CreateTable(
                "dbo.LicitanteProductoMarca",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitanteId = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        ProductoMarcaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licitante", t => t.LicitanteId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .ForeignKey("dbo.ProductoMarca", t => t.ProductoMarcaId)
                .Index(t => t.LicitanteId)
                .Index(t => t.ProductoId)
                .Index(t => t.ProductoMarcaId);
            
            CreateTable(
                "dbo.Licitador",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Licitante",
                c => new
                    {
                        Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Licitante", "Id", "dbo.Empresa");
            DropForeignKey("dbo.Licitador", "Id", "dbo.Empresa");
            DropForeignKey("dbo.LicitanteProductoMarca", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitanteProductoMarca", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.LicitanteProductoMarca", "LicitanteId", "dbo.Licitante");
            DropForeignKey("dbo.LicitacionOfertaPartida", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionPartidaId", "dbo.LicitacionPartidas");
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionOfertaId", "dbo.LicitacionOferta");
            DropForeignKey("dbo.Licitacion", "LicitadorId", "dbo.Licitador");
            DropForeignKey("dbo.LicitacionPartidas", "LicitacionId", "dbo.Licitacion");
            DropForeignKey("dbo.LicitacionPartidas", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoMarcas", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoMarcas", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitacionPartidaMarcas", "LicitacionPartidaId", "dbo.LicitacionPartidas");
            DropForeignKey("dbo.LicitacionPartidaMarcas", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitacionOferta", "LicitacionId", "dbo.Licitacion");
            DropForeignKey("dbo.LicitacionOferta", "LicitanteId", "dbo.Licitante");
            DropIndex("dbo.Licitante", new[] { "Id" });
            DropIndex("dbo.Licitador", new[] { "Id" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "ProductoMarcaId" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "ProductoId" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "LicitanteId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "ProductoMarcaId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionPartidaId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionOfertaId" });
            DropIndex("dbo.ProductoMarcas", new[] { "ProductoMarcaId" });
            DropIndex("dbo.ProductoMarcas", new[] { "ProductoId" });
            DropIndex("dbo.LicitacionPartidaMarcas", new[] { "ProductoMarcaId" });
            DropIndex("dbo.LicitacionPartidaMarcas", new[] { "LicitacionPartidaId" });
            DropIndex("dbo.LicitacionPartidas", new[] { "ProductoId" });
            DropIndex("dbo.LicitacionPartidas", new[] { "LicitacionId" });
            DropIndex("dbo.LicitacionOferta", new[] { "LicitanteId" });
            DropIndex("dbo.LicitacionOferta", new[] { "LicitacionId" });
            DropIndex("dbo.Licitacion", new[] { "LicitadorId" });
            DropTable("dbo.Licitante");
            DropTable("dbo.Licitador");
            DropTable("dbo.LicitanteProductoMarca");
            DropTable("dbo.LicitacionOfertaPartida");
            DropTable("dbo.ProductoMarcas");
            DropTable("dbo.Producto");
            DropTable("dbo.ProductoMarca");
            DropTable("dbo.LicitacionPartidaMarcas");
            DropTable("dbo.LicitacionPartidas");
            DropTable("dbo.LicitacionOferta");
            DropTable("dbo.Licitacion");
            DropTable("dbo.Empresa");
        }
    }
}
