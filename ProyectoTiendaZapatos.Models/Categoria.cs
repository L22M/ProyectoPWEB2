using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiendaZapatos.Models
{
    public class Categoria
    {
        public int Id { get; set; }

     
        public string Nombre { get; set; }

        public ICollection<Producto> Producto { get; set; }

        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }



    }
}
