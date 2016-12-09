using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table("Empresa")]
    public class Empresa : Entidad
    {
        [StringLength(200)]
        public String Nombre { get; set; }
    }
}
