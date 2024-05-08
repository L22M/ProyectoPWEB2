using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiendaZapatos.Models
{
    public class DetalleCompra
    {
        public int DetalleCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public Compra Compra { get; set; }
        public Producto Producto { get; set; }
    }
}
