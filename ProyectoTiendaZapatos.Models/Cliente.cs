using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProyectoTiendaZapatos.Models
{
    public class Cliente

    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public ICollection<Compra> Compras { get; set; }  // Colección de compras hechas por un cliente
        public ICollection<Venta> Ventas { get; set; }  // Colección de ventas realizadas a un cliente
    }
}
