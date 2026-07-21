using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Application.DTOs
{
    public class ProductoDTOs
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; } = true;

        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; }
    }
}
