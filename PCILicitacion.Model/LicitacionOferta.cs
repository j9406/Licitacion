using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitacionOferta" )]
    public class LicitacionOferta : Entidad
    {
        public Int64 LicitacionId { get; set; }
        [ForeignKey( "LicitacionId" )]
        public Licitacion Licitacion { get; set; }

        public Int64 LicitanteId { get; set; }
        [ForeignKey( "LicitanteId" )]
        public Licitante Licitante { get; set; }
        public DateTime FechaOferta { get; set; }
        public DateTime FechaVigencia { get; set; }
    }
}
