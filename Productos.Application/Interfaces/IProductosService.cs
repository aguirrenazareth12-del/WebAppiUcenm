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
        Task<IReadOnlyCollection<ProductoDTOs>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
        Task <ProductoDTOs> ObtenerProductoPorId(int id, CancellationToken cancellationToken = default);
        Task <ProductoDTOs> AgregarProductosAsync(CrearProductoDTOs producto, CancellationToken cancellationToken = default);
        Task <ProductoDTOs> ActualizarProductosAsync(ActualizarProductoDTOs producto, CancellationToken cancellationToken= default);
        Task<ProductoDTOs> EliminarProductosAsync(int id, CancellationToken cancellationToken = default);
    }
}
