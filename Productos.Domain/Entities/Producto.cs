using Productos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Domain.Entities
{
    public class Producto : BaseEntity
    {
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime FechaModificacion { get; set; }
    }
}
