namespace PuntoDeVenta.Entities
{
    public class ProductoAgrupador : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }

		public Categoria Categoria { get; set; }

		public Fabricante Fabricante { get; set; }
	}

}
