using PuntoDeVenta.Entities;
using PuntoDeVenta.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Logic
{
    public class PromocionesLogic
	{

		Repositorios repositorios;

		public PromocionesLogic(Repositorios repositorios)
		{
			this.repositorios = repositorios;
		}

		public void AplicarPromocionesPrecioSimple(OrdenDeCompra orden, Factura factura)
		{
			var promocionesSimples = repositorios.ObtenerPromocionesPrecioSimple();

			foreach (var promo in promocionesSimples)
			{
				AplicarPromocionPrecionSimple(promo, factura, orden);
			}
		}

		// <summary>
		/// Dada una promoción y una orden de compra, analiza los items, y si corresponde genera un descuento y lo agrega la factura
		/// </summary>
		/// <param name="factura"></param>
		/// <param name="orden"></param>
		/// <exception cref="NotImplementedException"></exception>
		public void AplicarPromocionPrecionSimple(PromocionPrecioSimple promo, Factura factura, OrdenDeCompra orden)
		{
			switch (promo.ObjetivoDePromocion)
			{
				case ObjetivoDePromocion.Producto:
					foreach (var item in orden.Items)
					{
						if (item.Producto.Id == promo.Producto.Id)
						{
							CrearDescuento(promo, item, factura);							
						}
					}
					break;

				case ObjetivoDePromocion.Categoria:
					foreach (var item in orden.Items)
					{
						if (item.Producto.ProductoAgrupador.Categoria.Id == promo.Categoria.Id)
						{
							CrearDescuento(promo, item, factura);							
						}
					}
					break;

				case ObjetivoDePromocion.CategoriaYFabricante:
					foreach (var item in orden.Items)
					{
						if (item.Producto.ProductoAgrupador.Categoria.Id == promo.Categoria.Id && item.Producto.ProductoAgrupador.Fabricante.Id == promo.Fabricante.Id)
						{
							CrearDescuento(promo, item, factura);							
						}
					}
					break;

				case ObjetivoDePromocion.Fabricante:
					foreach (var item in orden.Items)
					{
						if(item.Producto.ProductoAgrupador.Fabricante.Id == promo.Fabricante.Id)
						{
							CrearDescuento(promo, item, factura);
						}
					}
					break;

                case ObjetivoDePromocion.ProductoAgrupador:
                    foreach (var item in orden.Items)
                    {
                        if (item.Producto.ProductoAgrupador.Id == promo.ProductoAgrupador.Id)
                        {
                            CrearDescuento(promo, item, factura);
                        }
                    }
                    break;

                default:
					throw new NotImplementedException($"Falta definir como se aplica una promo del tipo {promo.ObjetivoDePromocion}");

			}
		}

		public FacturaDescuento CrearDescuento(PromocionPrecioSimple promo, OrdenDeCompraDetalle itemDeOrdenDeCompra, Factura factura)
		{
			var descuento = new FacturaDescuento(itemDeOrdenDeCompra.Producto, itemDeOrdenDeCompra.Cantidad, factura);

			switch (promo.TipoDeDescuento)
			{
				case TipoDeDescuento.Porcentaje:
					descuento.DescuentoUnitario = itemDeOrdenDeCompra.Producto.PrecioVenta * promo.ValorDeDescuento / 100;
					break;
				case TipoDeDescuento.Precio:
					descuento.DescuentoUnitario = itemDeOrdenDeCompra.Producto.PrecioVenta - promo.ValorDeDescuento;
					break;
				default:
					throw new NotImplementedException();

			}

			descuento.Promocion = promo;
			factura.Descuentos.Add(descuento);
			return descuento;			
		}


		public void AplicarPromocionesDeConjuntos(OrdenDeCompra orden, Factura factura)
		{
			var promociones = repositorios.ObtenerPromocionesDeConjuntos();

			foreach (var promo in promociones)
			{
				AplicarPromocionDeConjutos(promo, factura, orden);
			}
		}

		public void AplicarPromocionDeConjutos(PromocionPreciosPorConjuntos promo, Factura factura, OrdenDeCompra orden)
		{
			switch (promo.ObjetivoDePromocion)
			{
				case ObjetivoDePromocion.Producto:
					foreach (var item in orden.Items)
					{
						if (item.Producto.Id == promo.Producto.Id)
						{
							CrearDescuentoPromocionDeConjuntos(promo, item, factura);
						}
					}
					break;
				default:
					throw new NotImplementedException($"Falta definir como se aplica una promo del tipo {promo.ObjetivoDePromocion}");
			}
		}

		public FacturaDescuento CrearDescuentoPromocionDeConjuntos(PromocionPreciosPorConjuntos promo, OrdenDeCompraDetalle itemDeOrdenDeCompra, Factura factura)
		{
			// Ver si corresponde
			// No corresponde - retorno
			// Si corresponde: ver cuantos corresponden

			if (itemDeOrdenDeCompra.Cantidad < promo.CantidadConjunto)
			{
				return null;
			}

			// Corresponde: ver cuantos
			int cantidad = itemDeOrdenDeCompra.Cantidad / promo.CantidadConjunto;

			if (cantidad == 0)
			{
				return null;
			}

			var descuento = new FacturaDescuento(itemDeOrdenDeCompra.Producto, cantidad, factura);
			descuento.DescuentoUnitario = itemDeOrdenDeCompra.Producto.PrecioVenta;

			descuento.Promocion = promo;
			factura.Descuentos.Add(descuento);
			return descuento;
		}

	}
}
