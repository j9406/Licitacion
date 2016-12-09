using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "Licitante" )]
    public class Licitante : Empresa
    {
        public Licitante()
        {
            LicitacionOfertas = new HashSet<LicitacionOferta>();
        }

        //public Int64 EmpresaId { get; set; }
        //[ForeignKey( "EmpresaId" )]
        //public Empresa Empresa { get; set; }

        [InverseProperty( "Licitante" )]
        public ICollection<LicitacionOferta> LicitacionOfertas { get; set; }
    }
}
