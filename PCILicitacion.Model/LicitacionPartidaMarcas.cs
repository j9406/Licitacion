using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitacionPartidaMarcas" )]
    public class LicitacionPartidaMarcas : Entidad
    {
        public Int64 LicitacionPartidaId { get; set; }
        [ForeignKey( "LicitacionPartidaId" )]
        public LicitacionPartida LicitacionPartida { get; set; }

        public Int64 ProductoMarcaId { get; set; }
        [ForeignKey( "ProductoMarcaId" )]
        public ProductoMarca ProductoMarca { get; set; }
    }
}
