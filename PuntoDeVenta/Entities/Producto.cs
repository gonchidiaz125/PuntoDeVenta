namespace PuntoDeVenta.Entities
{
    public class Producto : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }
		public ProductoAgrupador ProductoAgrupador { get; set; }

		public double PrecioVenta { get; set; }
	}

}
