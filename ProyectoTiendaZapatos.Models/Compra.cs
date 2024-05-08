using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoTiendaZapatos.Models
{
   public class Compra

    {
        public int CompraId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
        public List<DetalleCompra> DetallesCompras { get; set; }
     
    }
}
