using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "LicitacionPartida" )]
    public class LicitacionPartida : Entidad
    {
        public Int64 LicitacionId { get; set; }
        [ForeignKey( "LicitacionId" )]
        public Licitacion Licitacion { get; set; }
        public String Observaciones { get; set; }
        
    }
}
