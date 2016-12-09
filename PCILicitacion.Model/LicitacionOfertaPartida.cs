using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitacionOfertaPartida" )]
    public class LicitacionOfertaPartida : Entidad
    {
        public Int64 LicitacionOfertaId { get; set; }
        [ForeignKey( "LicitacionOfertaId" )]
        public LicitacionOferta LicitacionOferta { get; set; }

        public Int64 LicitacionPartidaId { get; set; }
        [ForeignKey( "LicitacionPartidaId" )]
        public LicitacionPartida LicitacionPartida { get; set; }

    }
}
