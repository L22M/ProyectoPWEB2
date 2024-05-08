using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoTiendaZapatos.AccesoDatos.Data.Repository.IRepository;
using ProyectoTiendaZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoTiendaZapatos.AccesoDatos.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);
        IEnumerable<SelectListItem> GetListaCategoria();

    }
}
