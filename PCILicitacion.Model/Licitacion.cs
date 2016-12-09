using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("Licitacion")]
    public class Licitacion : Entidad
    {
        public Licitacion()
        {
            LicitacionPartidas = new HashSet<LicitacionPartida>();
            LicitacionOfertas = new HashSet<LicitacionOferta>();
        }
        [StringLength(200)]
        public String Nombre { get; set; }

        public Int64 LicitadorId { get; set; }
        [ForeignKey("LicitadorId")]
        public Licitador Licitador { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaCierre { get; set; }

        public DateTime FechaAdjudicacion { get; set; }

        public String Observaciones { get; set; }

        [InverseProperty( "Licitacion" )]
        public ICollection<LicitacionPartida> LicitacionPartidas { get; set; }
        [InverseProperty( "Licitacion" )]
        public ICollection<LicitacionOferta> LicitacionOfertas { get; set; }
    }
}
