using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitanteProducto" )]
    public class LicitanteProducto : Entidad
    {
        public LicitanteProducto()
        {
            LicitanteProductoMarcas = new HashSet<LicitanteProductoMarcas>();
        }

        public Int64 LicitanteId { get; set; }
        [ForeignKey( "LicitanteId" )]
        public Licitante Licitante { get; set; }
        public Int64 ProductoId { get; set; }
        [ForeignKey( "ProductoId" )]
        public Producto Producto { get; set; }

        [InverseProperty( "LicitanteProducto" )]
        public ICollection<LicitanteProductoMarcas> LicitanteProductoMarcas { get; set; }
    }
}
