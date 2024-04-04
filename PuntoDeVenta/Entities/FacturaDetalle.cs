namespace PuntoDeVenta.Entities
{
    public class FacturaDetalle: ClaseBase
	{
		public Producto Producto { get; set; }	
		public int Cantidad { get; set; }

		public double PrecioUnitario { get; set; }

		public double SubTotal { get {  return PrecioUnitario * Cantidad; } }
		
		public Factura Factura { get; set; }

		public FacturaDetalle(Producto producto, int cantidad, Factura factura)
		{
			Producto= producto;
			Cantidad = cantidad;
			Factura = factura;
		}
	}

}
