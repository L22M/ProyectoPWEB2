﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiendaZapatos.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }


        public string Marca { get; set; }

     
        public double Precio { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

     

        // Constructor para inicializar la colección de Productos
       
    }
}
