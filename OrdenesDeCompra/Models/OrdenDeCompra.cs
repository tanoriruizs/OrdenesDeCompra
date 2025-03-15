namespace OrdenesDeCompra.Models
{
    public class OrdenDeCompra
    {
        public int Id { get; set; }
        public string NumeroDeOrden { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public decimal MontoTotal { get; set; }
    }
}
