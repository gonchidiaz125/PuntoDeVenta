namespace PuntoDeVenta.Entities
{
    public class OrdenDeCompraDetalle : ClaseBase
	{
		public Producto Producto { get; set; }
		public int Cantidad { get; set; }

		public OrdenDeCompra OrdenDeCompra { get; set; }

		public OrdenDeCompraDetalle(Producto producto, int cantidad, OrdenDeCompra ordenDeCompra)
		{
			Producto = producto;
			Cantidad = cantidad;
			OrdenDeCompra = ordenDeCompra;
		}
	}

}
