using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitanteProductoMarcas" )]
    public class LicitanteProductoMarcas : Entidad
    {
        public Int64 LicitanteProductoId { get; set; }
        [ForeignKey( "LicitanteProductoId" )]
        public LicitanteProducto LicitanteProducto { get; set; }

        public Int64 ProductoMarcaId { get; set; }
        [ForeignKey( "ProductoMarcaId" )]
        public ProductoMarca ProductoMarca { get; set; }
    }
}
