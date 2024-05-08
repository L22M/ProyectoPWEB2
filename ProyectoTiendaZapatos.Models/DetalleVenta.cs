using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiendaZapatos.Models
{
    public class DetalleVenta
    {
        public int DetalleVentaId { get; set; } // Clave primaria
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
    }
}
