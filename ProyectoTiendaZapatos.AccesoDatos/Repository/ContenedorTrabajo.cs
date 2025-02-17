﻿using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;
using ProyectoTiendaZapatos.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoTiendaZapatos.Data;
using ProyectoTiendaZapatos.Models;
using ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository;
using ProyectoTiendaZapatos.AccesoDatos.Repository;



namespace ProyectoTiendaZapatos.AccesoDatos.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;
        public ContenedorTrabajo(ApplicationDbContext context)
        {
            _context = context;
            //se agregan cada uno de los repositorios para que queden encapsulados
           Producto = new ProductoRepository(_context);
            Categoria = new CategoriaRepository(_context);
            Cliente = new ClienteRepository(_context);
            Compra = new CompraRepository(_context);
            DetalleCompra = new DetalleCompraRepository(_context);
            Venta = new VentaRepository(_context);
            DetalleVenta = new DetalleVentaRepository(_context);
            //Usuario = new UsuarioRepository(_context);//
        }

        public IProductoRepository Producto { get; private set; }
        public ICategoriaRepository Categoria { get; private set; }

        public IProductoRepository producto => throw new NotImplementedException();

        public ICategoriaRepository CategoriaRepository => throw new NotImplementedException();

        public IProductoRepository ProductoRepository => throw new NotImplementedException();
        public IClienteRepository Cliente { get; private set; }
        public ICompraRepository Compra { get; private set; }
        public IDetalleCompraRepository DetalleCompra { get; private set; }
        public IVentaRepository Venta { get; private set; }
        public IDetalleVentaRepository DetalleVenta { get; private set; }

        //public IUsuarioRepository Usuario { get; private set; }//

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
