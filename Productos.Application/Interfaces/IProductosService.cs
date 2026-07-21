using Productos.Application.DTOs;
using Productos.Application.Services;
using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Application.Interfaces
{
    public interface IProductosService
    {
        Task<List<ProductoDTOs>> ObtenerProductos();
        Task<ProductoDTOs> ObtenerProductoPorId(int id);
        Task AgregarProductoAsync(CrearProductoDTOs producto);
        Task ActualizarProductoAsync(ActualizarProductoDTOs producto);
        Task<int> GuardarCambiosAsync();
    }
}
