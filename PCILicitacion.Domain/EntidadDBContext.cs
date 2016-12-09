using PCILicitacion.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Domain
{
    public class EntidadDBContext : DbContext
    {
        public EntidadDBContext() : base( "PCILicitacion" ) { }

        public DbSet<ProductoMarca> ProductoMarca { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoMarcas> ProductoMarcas { get; set; }

        public DbSet<Empresa> Empresa { get; set; }

        public DbSet<Licitador> Licitador { get; set; }
        public DbSet<Licitacion> Licitacion { get; set; }
        public DbSet<LicitacionAdjudicacion> LicitacionAdjudicacion  { get; set; }
        public DbSet<LicitacionPartida> LicitacionPartida { get; set; }
        public DbSet<LicitacionPartidaProducto> LicitacionPartidaProducto  { get; set; }
        public DbSet<LicitacionPartidaProductoMarcas> LicitacionPartidaProductoMarcas { get; set; }
        public DbSet<LicitacionOferta> LicitacionOferta { get; set; }
        public DbSet<LicitacionOfertaPartida> LicitacionOfertaPartida { get; set; }
        public DbSet<LicitacionOfertaPartidaProducto> LicitacionOfertaPartidaProducto { get; set; }

        public DbSet<Licitante> Licitante { get; set; }
        public DbSet<LicitanteProductoMarca> LicitanteProductoMarca { get; set; }
        //public DbSet<LicitanteProducto> LicitanteProducto { get; set; }
        //public DbSet<LicitanteProductoMarcas> LicitanteProductoMarcas { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }
}
