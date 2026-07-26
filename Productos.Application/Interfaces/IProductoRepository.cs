using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Application.Interfaces
{
    public interface IProductoRepository
    {
        Task<IReadOnlyCollection<Producto>> ObtenerTodosAsync(
            CancellationToken cancellationToken = default
            );
        Task<Producto> ObtenerProductoPorId(string Codigo, CancellationToken cancellationToken = default);
        Task AgregarProductoAsync(Producto producto, CancellationToken cancellationToken = default);
        Task ActualizarProductoAsync(Producto producto, CancellationToken cancellationToken= default);
        Task<int> GuardarCambiosAsync(CancellationToken cancellationToken = default);
        Task ObtenerProductoPorId(object codigo, CancellationToken cancellationToken);
        void EliminarProductoAsync(object producto, CancellationToken cancellationToken);
    }
}
