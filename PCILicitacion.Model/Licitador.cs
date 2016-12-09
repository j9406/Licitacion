using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "Licitador" )]
    public class Licitador : Empresa
    {
        public Licitador()
        {
            Licitaciones = new HashSet<Licitacion>();
        }

        //public Int64 EmpresaId { get; set; }
        //[ForeignKey("EmpresaId")]
        //public Empresa Empresa { get; set; }

        [InverseProperty( "Licitador" )]
        public ICollection<Licitacion> Licitaciones { get; set; }
    }
}
