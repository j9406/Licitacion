using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("LicitacionPartidaProducto")]
    public class LicitacionPartidaProducto : Entidad
    {
        public Int64 LicitacionPartidaId { get; set; }
        [ForeignKey("LicitacionPartidaId")]
        public LicitacionPartida LicitacionPartida { get; set; }

        public Int64 ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public String Observaciones { get; set; }

    }
}
