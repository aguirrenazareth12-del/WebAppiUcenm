using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<List<Producto>> ObtenerProductos();
        Task<Producto> ObtenerProductoPorId(int id);
        Task AgregarProductoAsync(Producto producto);
        Task ActualizarProductoAsync(Producto producto);
        Task<int> GuardarCambiosAsync();
    }
}
