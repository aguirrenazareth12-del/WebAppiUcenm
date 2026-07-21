using Productos.Application.DTOs;
using Productos.Application.Interfaces;
using Productos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Productos.Application.Services
{
    public class ProductService : IProductosService
    {
        private readonly IProductoRepository _productoRepository;
        public ProductService(IProductoRepository productoRepository) { 
            _productoRepository = productoRepository;
            }

        public Task ActualizarProductoAsync(ActualizarProductoDTOs producto)
        {
            throw new NotImplementedException();
        }
        #region implementation of IProductoService
        /* Este es el implement de agregar un producto */

        public Task AgregarProductoAsync(CrearProductosDTOs producto)
        {
            var codigo = producto.Codigo.Trim().ToUpperInvariant();
            var nuevoProducto = new Producto
            {
                Codigo = codigo,
                Nombre = producto.Nombre.Trim(),
                Precio = producto.Precio,
                Existencia = producto.Existencia,
                Activo = producto.Activo,
                FechaModificacion = DateTime.UtcNow
            };

            return _productoRepository.AgregarProductoAsync(nuevoProducto);
        }

        public Task AgregarProductoAsync(CrearProductoDTOs producto)
        {
            throw new NotImplementedException();
        }

        #endregion

        Task<int> IProductosService.GuardarCambiosAsync()
        {
            throw new NotImplementedException();
        }

        Task<ProductoDTOs> IProductosService.ObtenerProductoPorId(int id)
        {
            throw new NotImplementedException();
        }

        Task<List<ProductoDTOs>> IProductosService.ObtenerProductos()
        {
            throw new NotImplementedException();
        }
    }
}
