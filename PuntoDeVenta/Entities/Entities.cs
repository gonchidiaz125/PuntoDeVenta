
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

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

	public class OrdenDeCompra : ClaseBase
	{
        public DateTime Fecha { get; set; }

		public List<OrdenDeCompraDetalle> Items { get; set; }

		public OrdenDeCompra()
		{
			Items = new List<OrdenDeCompraDetalle>();
		}

	}

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

	public class Factura: ClaseBase
	{
        public int Numero { get; set; }
		public DateTime Fecha { get; set; }

		public List<FacturaDetalle> Items { get; set; }
		public List<FacturaDescuento> Descuentos { get; set; }

		public Factura()
		{
			Items = new List<FacturaDetalle>();
			Descuentos = new List<FacturaDescuento> { };
		}

    }

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

	public interface IPromocion
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public DateTime FechaDesde { get; set; }
		public DateTime FechaHasta { get; set; }

		public ObjetivoDePromocion ObjetivoDePromocion { get; set; }
	}

	public abstract class PromocionBase : ClaseBase, IPromocion
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

	public class PromocionPrecioSimple : PromocionBase, IPromocion
	{        			
		public TipoDeDescuento TipoDeDescuento { get; set; }

		public int ValorDeDescuento { get; set; }

		public string ObtenerDescripcionDelDescuento()
		{
			switch (TipoDeDescuento)
			{
				case TipoDeDescuento.Precio:
					return $"Valor final ${ValorDeDescuento}";

				case TipoDeDescuento.Porcentaje:
					return $"{ValorDeDescuento}% de descuento";
			
				default:
					throw new NotImplementedException();
			}			
		}
		
	}


	public class PromocionPreciosPorCantidad : PromocionBase, IPromocion
	{		
		public TipoDeDescuento TipoDePromocion { get; set; }

		public int ValorDeDescuento { get; set; }
		
		public int CantidadDesde { get; set; }
	}

	public class PromocionPreciosPorConjuntos : PromocionBase
	{
		public int CantidadConjunto { get; set; }
		public int CantidadDescontada { get; set; }
	}

}
