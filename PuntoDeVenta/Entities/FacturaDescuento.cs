namespace PuntoDeVenta.Entities
{
    public class FacturaDescuento : ClaseBase
	{
		public Producto Producto { get; set; }

		public int Cantidad { get; set; }

		public double DescuentoUnitario { get; set; }

		public double SubTotal { get { return DescuentoUnitario * Cantidad; } }

		public Factura Factura { get; set; }

		public IPromocion Promocion { get; set; }

		public FacturaDescuento(Producto producto, int cantidad, Factura factura)
		{
			Producto = producto;
			Cantidad = cantidad;
			Factura = factura;
		}
	}

}
