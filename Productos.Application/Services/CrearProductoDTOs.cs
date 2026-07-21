namespace Productos.Application.Services
{
    public class CrearProductoDTOs
    {
        public object Codigo { get; internal set; }
        public bool Activo { get; internal set; }
        public int Existencia { get; internal set; }
        public decimal Precio { get; internal set; }
        public object Nombre { get; internal set; }
    }
}