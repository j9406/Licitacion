using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCILicitacion.Model
{
    [Table( "ProductoMarcas" )]
    public class ProductoMarcas : Entidad
    {
        public Int64 ProductoId { get; set; }
        [ForeignKey( "ProductoId" )]
        public Producto Producto { get; set; }

        public Int64 ProductoMarcaId { get; set; }
        [ForeignKey( "ProductoMarcaId" )]
        public ProductoMarca ProductoMarca { get; set; }
    }
}
