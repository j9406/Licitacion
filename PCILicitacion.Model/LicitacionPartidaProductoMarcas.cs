using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("LicitacionPartidaProductoMarcas")]
    public class LicitacionPartidaProductoMarcas : Entidad
    {
        public Int64 LicitacionPartidaProductoId { get; set; }
        [ForeignKey("LicitacionPartidaProductoId")]
        public LicitacionPartidaProducto LicitacionPartidaProducto { get; set; }

        public Int64 ProductoMarcaId { get; set; }
        [ForeignKey("ProductoMarcaId")]
        public ProductoMarca ProductoMarca { get; set; }
    }
}
