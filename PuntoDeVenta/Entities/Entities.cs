
namespace PuntoDeVenta.Entities
{
	public class ClaseBase
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
	}

	public class Fabricante : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }

	}

	public class Categoria : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }
	}

	public class ProductoAgrupador : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }

		public Categoria Categoria { get; set; }

		public Fabricante Fabricante { get; set; }
	}

	public class Producto : ClaseBase
	{
		//public int Id { get; set; }
		//public string Nombre { get; set; }
		public ProductoAgrupador ProductoAgrupador { get; set; }

		public double PrecioVenta { get; set; }
	}
}
