namespace PCILicitacion.Domain.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PCILicitacion.Domain.EntidadDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PCILicitacion.Domain.EntidadDBContext db)
        {   //This method will be called after migrating to the latest version.
            //DbSet<T>.AddOrUpdate() helper extension method avoid creating duplicate seed data. E.g.

            db.ProductoMarca.AddOrUpdate( productoMarca => productoMarca.Id
                , new ProductoMarca { Id = 1, Nombre = "Dell" }
                , new ProductoMarca { Id = 2, Nombre = "HP" }
                , new ProductoMarca { Id = 3, Nombre = "Lenovo" }
            );
            db.Producto.AddOrUpdate( producto => producto.Id
                , new Producto { Id = 1, Nombre = "Impresora" }
                , new Producto { Id = 2, Nombre = "Portatil" }
                , new Producto { Id = 3, Nombre = "Tablet" }
            );
            db.ProductoMarcas.AddOrUpdate( productoMarcas => productoMarcas.Id
                , new ProductoMarcas { Id = 1, ProductoId = 1, ProductoMarcaId = 1 }
                , new ProductoMarcas { Id = 2, ProductoId = 1, ProductoMarcaId = 2 }
                , new ProductoMarcas { Id = 3, ProductoId = 2, ProductoMarcaId = 1 }
                , new ProductoMarcas { Id = 4, ProductoId = 2, ProductoMarcaId = 2 }
                , new ProductoMarcas { Id = 5, ProductoId = 2, ProductoMarcaId = 3 }
                , new ProductoMarcas { Id = 6, ProductoId = 3, ProductoMarcaId = 2 }
                , new ProductoMarcas { Id = 7, ProductoId = 3, ProductoMarcaId = 3 }
            );

            //db.Empresa.AddOrUpdate( empresa => empresa.Id
            //    , new Empresa { Id = 1, Nombre = "Renasci" }
            //    //, new Empresa { Id = 2, Nombre = "PCIServicios" }
            //);

            //db.Licitante.AddOrUpdate( licitante => licitante.Id
            //    , new Licitante { Id = 1, EmpresaId = 2 }
            ////);
            //db.Licitante.AddOrUpdate( licitante => licitante.Id
            //    , new Licitante { Id = 2, Nombre = "PCIServiciosX" }
            //);
            //db.LicitanteProductoMarca.AddOrUpdate( licitanteProductoMarca => licitanteProductoMarca.Id
            //    , new LicitanteProductoMarca { Id = 1, LicitanteId = 2, ProductoId = 2, ProductoMarcaId = 1 }
            //    , new LicitanteProductoMarca { Id = 2, LicitanteId = 2, ProductoId = 3, ProductoMarcaId = 3 }
            //);
            ////db.LicitanteProducto.AddOrUpdate( licitanteProducto => licitanteProducto.LicitanteId
            ////    , new LicitanteProducto { LicitanteId = 1, ProductoId = 2}
            ////    , new LicitanteProducto { LicitanteId = 1, ProductoId = 3}
            ////);
            ////db.LicitanteProductoMarcas.AddOrUpdate( licitanteProductoMarcas => licitanteProductoMarcas.LicitanteProductoId
            ////    , new LicitanteProductoMarcas { LicitanteProductoId = 1, ProductoMarcaId = 1 }
            ////    , new LicitanteProductoMarcas { LicitanteProductoId = 2, ProductoMarcaId = 3 }
            ////);

            ////db.Licitador.AddOrUpdate( licitador => licitador.Id
            ////    , new Licitador { Id = 1, EmpresaId = 1 }
            ////);
            //db.Licitador.AddOrUpdate( licitador => licitador.Id
            //    , new Licitador { Id = 1, Nombre = "Rénasci" }
            //);

            //db.Licitacion.AddOrUpdate( licitacion => licitacion.Id
            //    , new Licitacion { Id = 1, LicitadorId = 1, FechaCreacion = new DateTime( 2017, 2, 1 ), FechaCierre = new DateTime( 2017, 2, 14 ), FechaAdjudicacion = new DateTime( 2017, 2, 21 ) }
            //);
            ////db.LicitacionPartida.AddOrUpdate( licitacionPartida => licitacionPartida.Id
            ////    , new LicitacionPartida { Id = 1, LicitacionId = 1, ProductoId = 1, Cantidad = 10 }
            ////    , new LicitacionPartida { Id = 2, LicitacionId = 1, ProductoId = 2, Cantidad = 20 }
            ////);
            ////db.LicitacionPartidaMarcas.AddOrUpdate( licitacionPartidaMarcas => licitacionPartidaMarcas.Id
            ////    , new LicitacionPartidaMarcas { Id = 1, LicitacionPartidaId = 1, ProductoMarcaId = 2 }
            ////    , new LicitacionPartidaMarcas { Id = 2, LicitacionPartidaId = 2, ProductoMarcaId = 1 }
            ////);

            //db.LicitacionOferta.AddOrUpdate( licitacionOferta => licitacionOferta.Id
            //    , new LicitacionOferta { Id = 1, LicitacionId = 1, FechaOferta = new DateTime( 2017, 2, 7 ), FechaVigencia = new DateTime( 2017, 2, 28 ), LicitanteId = 2 }
            //);
            ////db.LicitacionOfertaPartida.AddOrUpdate( licitacionOfertaPartida => licitacionOfertaPartida.Id
            ////    , new LicitacionOfertaPartida { Id = 1, LicitacionOfertaId = 1, LicitacionPartidaId = 2, ProductoMarcaId = 1, Precio = 200000 }
            ////);
        }
    }

}
