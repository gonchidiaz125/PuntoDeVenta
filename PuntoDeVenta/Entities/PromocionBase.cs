namespace PuntoDeVenta.Entities
{
    public class PromocionBase : ClaseBase, IPromocion
	{
		public DateTime FechaDesde { get; set; }
		public DateTime FechaHasta { get; set; }

		public ObjetivoDePromocion ObjetivoDePromocion { get; set; }

		public Producto? Producto { get; set; }
		public ProductoAgrupador? ProductoAgrupador { get; set; }
		public Categoria? Categoria { get; set; }
		public Fabricante? Fabricante { get; set; }

		public string ObtenerObjetivoDePromocion()
		{
			switch (ObjetivoDePromocion)
			{
				case ObjetivoDePromocion.Producto:
					return Producto.Nombre;					

				case ObjetivoDePromocion.ProductoAgrupador:
					return ProductoAgrupador.Nombre;

				case ObjetivoDePromocion.Categoria:
					return Categoria.Nombre;

				case ObjetivoDePromocion.Fabricante:
					return Fabricante.Nombre;

				case ObjetivoDePromocion.CategoriaYFabricante:
					return $"{Categoria.Nombre} de {Fabricante.Nombre}";
			}

			return "";
		}

		public override string ToString()
		{
			return $"Id: {Id}  -  { Nombre }";
		}
	}

}
