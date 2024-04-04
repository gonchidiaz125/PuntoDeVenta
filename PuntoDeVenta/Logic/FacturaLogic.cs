using PuntoDeVenta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Logic
{
	public class FacturaLogic
	{
		Repositorios repositorios;

		public FacturaLogic(Repositorios repositorios)
		{
			this.repositorios = repositorios;
		}

		public void GenerarFactura(OrdenDeCompra orden)
		{
			var factura = new Factura();

			AplicarPromociones(orden, factura);

			ImprimirFactura(factura);
		}

		public void AplicarPromociones(OrdenDeCompra orden, Factura factura)
		{			
			var promocionesLogic = new PromocionesLogic(repositorios);
			promocionesLogic.AplicarPromociones(orden, factura);
		}

		public void ImprimirFactura(Factura factura)
		{
			Console.WriteLine("Descuentos");
			Console.WriteLine("----------");

			foreach (var dto in factura.Descuentos)
			{
				Console.WriteLine($"Descuento en {dto.Producto.Nombre} - Cantidad: {dto.Cantidad} * ${dto.DescuentoUnitario} - Total: {dto.Cantidad * dto.DescuentoUnitario}  - Promo aplicada: {dto.Promocion.Nombre}");
			}
		}
	}
}
