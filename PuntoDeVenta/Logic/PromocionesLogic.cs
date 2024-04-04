using PuntoDeVenta.Entities;
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

		public void AplicarPromociones(OrdenDeCompra orden, Factura factura)
		{
			var promocionesSimples = repositorios.ObtenerPromocionesPrecioSimple();

			foreach (var promo in promocionesSimples)
			{
				AplicarPromocion(promo, factura, orden);
			}
		}

		// <summary>
		/// Dada una promoción y una orden de compra, analiza los items, y si corresponde genera un descuento y lo agrega la factura
		/// </summary>
		/// <param name="factura"></param>
		/// <param name="orden"></param>
		/// <exception cref="NotImplementedException"></exception>
		public void AplicarPromocion(PromocionPrecioSimple promo, Factura factura, OrdenDeCompra orden)
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

	}
}
