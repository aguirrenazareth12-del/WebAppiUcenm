using Productos.Application.DTOs;
using Productos.Application.Interfaces;
using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Productos.Application.Services
{
    public class ProductService : IProductosService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        #region Implementation of IProductosService

        public async Task<ProductoDTOs> AgregarProductoAsync(CrearProductoDTOs producto, CancellationToken cancellationToken = default)
        {
            var nuevoProducto = new Producto
            {
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Existencia = producto.Existencia,
            };

            await _productoRepository.AgregarProductoAsync(nuevoProducto, cancellationToken);
            await _productoRepository.GuardarCambiosAsync(cancellationToken);

            return new ProductoDTOs
            {
                Id = nuevoProducto.Id,
                Nombre = nuevoProducto.Nombre,
                Precio = nuevoProducto.Precio,
                Existencia = nuevoProducto.Existencia,
            };
        }

        public async Task<ProductoDTOs> ObtenerProductoPorId(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id), "El ID del producto debe ser mayor que cero.");
            }

            var producto = await _productoRepository.ObtenerProductoPorId(id, cancellationToken);

            if (producto == null) return null;

            return new ProductoDTOs
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Existencia = producto.Existencia,
                Activo = producto.Activo,
                FechaCreacion = producto.FechaCreacion,
                FechaModificacion = producto.FechaModificacion,
            };
        }

        public async Task<IReadOnlyCollection<ProductoDTOs>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
        {
            var productos = await _productoRepository.ObtenerTodosAsync(cancellationToken);

            var productosDTO = productos.Select(producto => new ProductoDTOs
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Existencia = producto.Existencia,
                Activo = producto.Activo,
                FechaCreacion = producto.FechaCreacion,
                FechaModificacion = producto.FechaModificacion,
            }).ToList();

            return productosDTO.AsReadOnly();
        }

        public async Task<ProductoDTOs> ActualizarProductosAsync(ActualizarProductoDTOs producto, CancellationToken cancellationToken = default)
        {
            if (producto == null)
            {
                throw new ArgumentNullException(nameof(producto));
            }

            var productoExistente = await _productoRepository.ObtenerProductoPorId(producto.Id, cancellationToken);

            if (productoExistente == null)
            {
                throw new ArgumentException($"No se encontró un producto con el ID {producto.Id}.", nameof(producto));
            }

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Precio = producto.Precio;
            productoExistente.Existencia = producto.Existencia;
            productoExistente.Activo = producto.Activo;

            await _productoRepository.ActualizarProductoAsync(productoExistente, cancellationToken);
            await _productoRepository.GuardarCambiosAsync(cancellationToken);

            return new ProductoDTOs
            {
                Id = productoExistente.Id,
                Codigo = productoExistente.Codigo,
                Nombre = productoExistente.Nombre,
                Precio = productoExistente.Precio,
                Existencia = productoExistente.Existencia,
                Activo = productoExistente.Activo,
                FechaCreacion = productoExistente.FechaCreacion,
                FechaModificacion = productoExistente.FechaModificacion
            };
        }

        public async Task<ProductoDTOs> EliminarProductosAsync(int id, CancellationToken cancellationToken = default)
        {
            if (id <= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(id));
            }

            var producto = await _productoRepository.ObtenerProductoPorId(id, cancellationToken);
            if (producto == null)
            {
                throw new ArgumentException($"No se encontró un producto con el ID {id}.", nameof(id));
            }

            await _productoRepository.EliminarProductoAsync(producto, cancellationToken);
            await _productoRepository.GuardarCambiosAsync(cancellationToken);

            return new ProductoDTOs
            {
                Id = producto.Id,
                Codigo = producto.Codigo,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Existencia = producto.Existencia,
                Activo = producto.Activo,
                FechaCreacion = producto.FechaCreacion,
                FechaModificacion = producto.FechaModificacion
            };
        }

        #endregion
    }
}