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
                        Nombre = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Licitacion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        LicitadorId = c.Long(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(nullable: false),
                        FechaAdjudicacion = c.DateTime(nullable: false),
                        Observaciones = c.String(),
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
                "dbo.LicitacionPartida",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionId = c.Long(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licitacion", t => t.LicitacionId)
                .Index(t => t.LicitacionId);
            
            CreateTable(
                "dbo.LicitacionAdjudicacion",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionId = c.Long(nullable: false),
                        LicitacionPartidaId = c.Long(nullable: false),
                        LicitanteId = c.Long(nullable: false),
                        LicitacionOfertaPartidaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Licitacion", t => t.LicitacionId)
                .ForeignKey("dbo.LicitacionOfertaPartida", t => t.LicitacionOfertaPartidaId)
                .ForeignKey("dbo.LicitacionPartida", t => t.LicitacionPartidaId)
                .ForeignKey("dbo.Licitante", t => t.LicitanteId)
                .Index(t => t.LicitacionId)
                .Index(t => t.LicitacionPartidaId)
                .Index(t => t.LicitanteId)
                .Index(t => t.LicitacionOfertaPartidaId);
            
            CreateTable(
                "dbo.LicitacionOfertaPartida",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionOfertaId = c.Long(nullable: false),
                        LicitacionPartidaId = c.Long(nullable: false),
                        LicitacionPartidaProductoId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicitacionOferta", t => t.LicitacionOfertaId)
                .ForeignKey("dbo.LicitacionPartida", t => t.LicitacionPartidaId)
                .ForeignKey("dbo.LicitacionPartidaProducto", t => t.LicitacionPartidaProductoId)
                .Index(t => t.LicitacionOfertaId)
                .Index(t => t.LicitacionPartidaId)
                .Index(t => t.LicitacionPartidaProductoId);
            
            CreateTable(
                "dbo.LicitacionPartidaProducto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionPartidaId = c.Long(nullable: false),
                        ProductoId = c.Long(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Observaciones = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicitacionPartida", t => t.LicitacionPartidaId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.LicitacionPartidaId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
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
                "dbo.ProductoMarca",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicitacionOfertaPartidaProducto",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionOfertaPartidaId = c.Long(nullable: false),
                        LicitacionPartidaProductoMarcasId = c.Long(nullable: false),
                        LicitacionPartidaProductoId = c.Long(nullable: false),
                        PrecioUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicitacionOfertaPartida", t => t.LicitacionOfertaPartidaId)
                .ForeignKey("dbo.LicitacionPartidaProducto", t => t.LicitacionPartidaProductoId)
                .ForeignKey("dbo.LicitacionPartidaProductoMarcas", t => t.LicitacionPartidaProductoMarcasId)
                .Index(t => t.LicitacionOfertaPartidaId)
                .Index(t => t.LicitacionPartidaProductoMarcasId)
                .Index(t => t.LicitacionPartidaProductoId);
            
            CreateTable(
                "dbo.LicitacionPartidaProductoMarcas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LicitacionPartidaProductoId = c.Long(nullable: false),
                        ProductoMarcaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicitacionPartidaProducto", t => t.LicitacionPartidaProductoId)
                .ForeignKey("dbo.ProductoMarca", t => t.ProductoMarcaId)
                .Index(t => t.LicitacionPartidaProductoId)
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
            DropForeignKey("dbo.LicitacionOfertaPartidaProducto", "LicitacionPartidaProductoMarcasId", "dbo.LicitacionPartidaProductoMarcas");
            DropForeignKey("dbo.LicitacionPartidaProductoMarcas", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitacionPartidaProductoMarcas", "LicitacionPartidaProductoId", "dbo.LicitacionPartidaProducto");
            DropForeignKey("dbo.LicitacionOfertaPartidaProducto", "LicitacionPartidaProductoId", "dbo.LicitacionPartidaProducto");
            DropForeignKey("dbo.LicitacionOfertaPartidaProducto", "LicitacionOfertaPartidaId", "dbo.LicitacionOfertaPartida");
            DropForeignKey("dbo.LicitacionAdjudicacion", "LicitanteId", "dbo.Licitante");
            DropForeignKey("dbo.LicitacionAdjudicacion", "LicitacionPartidaId", "dbo.LicitacionPartida");
            DropForeignKey("dbo.LicitacionAdjudicacion", "LicitacionOfertaPartidaId", "dbo.LicitacionOfertaPartida");
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionPartidaProductoId", "dbo.LicitacionPartidaProducto");
            DropForeignKey("dbo.LicitacionPartidaProducto", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoMarcas", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoMarcas", "ProductoMarcaId", "dbo.ProductoMarca");
            DropForeignKey("dbo.LicitacionPartidaProducto", "LicitacionPartidaId", "dbo.LicitacionPartida");
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionPartidaId", "dbo.LicitacionPartida");
            DropForeignKey("dbo.LicitacionOfertaPartida", "LicitacionOfertaId", "dbo.LicitacionOferta");
            DropForeignKey("dbo.LicitacionAdjudicacion", "LicitacionId", "dbo.Licitacion");
            DropForeignKey("dbo.Licitacion", "LicitadorId", "dbo.Licitador");
            DropForeignKey("dbo.LicitacionPartida", "LicitacionId", "dbo.Licitacion");
            DropForeignKey("dbo.LicitacionOferta", "LicitacionId", "dbo.Licitacion");
            DropForeignKey("dbo.LicitacionOferta", "LicitanteId", "dbo.Licitante");
            DropIndex("dbo.Licitante", new[] { "Id" });
            DropIndex("dbo.Licitador", new[] { "Id" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "ProductoMarcaId" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "ProductoId" });
            DropIndex("dbo.LicitanteProductoMarca", new[] { "LicitanteId" });
            DropIndex("dbo.LicitacionPartidaProductoMarcas", new[] { "ProductoMarcaId" });
            DropIndex("dbo.LicitacionPartidaProductoMarcas", new[] { "LicitacionPartidaProductoId" });
            DropIndex("dbo.LicitacionOfertaPartidaProducto", new[] { "LicitacionPartidaProductoId" });
            DropIndex("dbo.LicitacionOfertaPartidaProducto", new[] { "LicitacionPartidaProductoMarcasId" });
            DropIndex("dbo.LicitacionOfertaPartidaProducto", new[] { "LicitacionOfertaPartidaId" });
            DropIndex("dbo.ProductoMarcas", new[] { "ProductoMarcaId" });
            DropIndex("dbo.ProductoMarcas", new[] { "ProductoId" });
            DropIndex("dbo.LicitacionPartidaProducto", new[] { "ProductoId" });
            DropIndex("dbo.LicitacionPartidaProducto", new[] { "LicitacionPartidaId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionPartidaProductoId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionPartidaId" });
            DropIndex("dbo.LicitacionOfertaPartida", new[] { "LicitacionOfertaId" });
            DropIndex("dbo.LicitacionAdjudicacion", new[] { "LicitacionOfertaPartidaId" });
            DropIndex("dbo.LicitacionAdjudicacion", new[] { "LicitanteId" });
            DropIndex("dbo.LicitacionAdjudicacion", new[] { "LicitacionPartidaId" });
            DropIndex("dbo.LicitacionAdjudicacion", new[] { "LicitacionId" });
            DropIndex("dbo.LicitacionPartida", new[] { "LicitacionId" });
            DropIndex("dbo.LicitacionOferta", new[] { "LicitanteId" });
            DropIndex("dbo.LicitacionOferta", new[] { "LicitacionId" });
            DropIndex("dbo.Licitacion", new[] { "LicitadorId" });
            DropTable("dbo.Licitante");
            DropTable("dbo.Licitador");
            DropTable("dbo.LicitanteProductoMarca");
            DropTable("dbo.LicitacionPartidaProductoMarcas");
            DropTable("dbo.LicitacionOfertaPartidaProducto");
            DropTable("dbo.ProductoMarca");
            DropTable("dbo.ProductoMarcas");
            DropTable("dbo.Producto");
            DropTable("dbo.LicitacionPartidaProducto");
            DropTable("dbo.LicitacionOfertaPartida");
            DropTable("dbo.LicitacionAdjudicacion");
            DropTable("dbo.LicitacionPartida");
            DropTable("dbo.LicitacionOferta");
            DropTable("dbo.Licitacion");
            DropTable("dbo.Empresa");
        }
    }
}
