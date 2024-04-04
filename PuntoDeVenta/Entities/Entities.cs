
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace PuntoDeVenta.Entities
{

    public enum TipoDeDescuento
	{
		Porcentaje,
		Precio
	}

	public enum ObjetivoDePromocion
	{
		Producto,
		ProductoAgrupador,
		Categoria,
		Fabricante,
		CategoriaYFabricante
	}

}
