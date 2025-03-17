using System.ComponentModel.DataAnnotations;

namespace OrdenesDeCompra.Models
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El número de orden es obligatorio")]
        public string NumeroDeOrden { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El proveedor es obligatorio")]
        [StringLength(100, ErrorMessage = "El proveedor no puede tener más de 100 caracteres")]
        public string Proveedor { get; set; }

        [Required(ErrorMessage = "El monto total es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto total debe ser mayor que 0")]
        public decimal MontoTotal { get; set; }
    }
}
