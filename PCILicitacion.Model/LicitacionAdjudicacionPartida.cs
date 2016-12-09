using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("LicitacionAdjudicacion")]
    public class LicitacionAdjudicacion : Entidad
    {
        public Int64 LicitacionId { get; set; }
        [ForeignKey("LicitacionId")]
        public Licitacion Licitacion { get; set; }

        public Int64 LicitacionPartidaId { get; set; }
        [ForeignKey("LicitacionPartidaId")]
        public LicitacionPartida LicitacionPartida  { get; set; }

        public Int64 LicitanteId { get; set; }
        [ForeignKey("LicitanteId")]
        public Licitante Licitante { get; set; }

        public Int64 LicitacionOfertaPartidaId { get; set; }
        [ForeignKey("LicitacionOfertaPartidaId")]
        public LicitacionOfertaPartida LicitacionOfertaPartida { get; set; }
    }
}
