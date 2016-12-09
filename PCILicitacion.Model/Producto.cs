using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "Producto" )]
    public class Producto : Entidad
    {
        public Producto()
        {
            ProductoMarcas = new HashSet<ProductoMarcas>();
        }
        [StringLength(200)]
        public String Nombre { get; set; }
        public String Descripcion { get; set; }

        [InverseProperty( "Producto" )]
        public ICollection<ProductoMarcas> ProductoMarcas { get; set; }
    }   
}
