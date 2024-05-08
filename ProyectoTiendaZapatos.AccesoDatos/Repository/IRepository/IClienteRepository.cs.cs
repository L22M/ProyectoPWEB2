using ProyectoTiendaZapatos.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Update(Cliente cliente);
        
    }
}
