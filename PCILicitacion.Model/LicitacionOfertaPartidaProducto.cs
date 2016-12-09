using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("LicitacionOfertaPartidaProducto")]
    public class LicitacionOfertaPartidaProducto : Entidad
    {
        public Int64 LicitacionOfertaPartidaId { get; set; }
        [ForeignKey("LicitacionOfertaPartidaId")]
        public LicitacionOfertaPartida LicitacionOfertaPartida { get; set; }

        public Int64 LicitacionPartidaProductoMarcasId { get; set; }
        [ForeignKey("LicitacionPartidaProductoMarcasId")]
        public LicitacionPartidaProductoMarcas LicitacionPartidaProductoMarcas { get; set; }

        public Int64 LicitacionPartidaProductoId { get; set; }
        [ForeignKey("LicitacionPartidaProductoId")]
        public LicitacionPartidaProducto LicitacionPartidaProducto { get; set; }

        public float PrecioUnitario { get; set; }

    }
}
