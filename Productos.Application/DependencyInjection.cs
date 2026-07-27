using Microsoft.Extensions.DependencyInjection;
using Productos.Application.Interfaces;
using Productos.Application.Services;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Productos.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register application services and depencies here
            // For example:
           services.AddScoped<IProductosService, ProductService>();
            return services;
        }
        
    }
}
