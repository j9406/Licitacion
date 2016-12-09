using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    public abstract class Entidad
    {
        [Key]
        [Column( Order = 0 )]
        public Int64 Id
        { get; set; }
    }
}
