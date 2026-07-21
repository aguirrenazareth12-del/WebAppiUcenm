using System;
using System.Collections.Generic;
using System.Text;

namespace Productos.Domain.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime FechaModificacion { get; set; }
    }
}
