using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Productos.Application.DTOs
{
    public class CrearProductosDTOs
    {
        [Required(ErrorMessage ="El codigo es requerido.")]
        [StringLength(30)]
        public string Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El nombre del producto es requerido.")]
        [StringLength (150)]
        public string Nombre { get; set; } = string.Empty;
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "La existencia debe ser mayor o igual que cero.")]
        public int Existencia { get; set; }
        public bool Activo { get; set; } = true;
    }
}
