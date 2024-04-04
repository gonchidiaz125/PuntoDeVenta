using PuntoDeVenta.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Entities
{
	public class Repositorios
	{
		private int fabricanteId = 0;
		private int categoriasId = 0;
		private int productosAgrupadoresId = 0;
		private int productosId = 0;

		private List<Fabricante> fabricantes = new List<Fabricante>();
		private List<Categoria> categorias = new List<Categoria>();
		private List<ProductoAgrupador> productosAgrupadores = new List<ProductoAgrupador>();
		private List<Producto> productos = new List<Producto>();

		private int promocionSimpleId = 0;
		private List<PromocionPrecioSimple> promocionesSimples = new List<PromocionPrecioSimple>();

		private int promocionPreciosPorConjuntosId = 0;
		private List<PromocionPreciosPorConjuntos> promocionesDeConjuntos = new List<PromocionPreciosPorConjuntos>();
		


		public Repositorios() {
			InicializarDatos();
		}

		private void InicializarDatos()
		{		
			// Utilizo constantes porque para evitar repetir el mismo nombre multiples veces y facilitar el mantenimiento
			// FABRICANTES
			

			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_BODEGA_RUTINI));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_LA_CAROYENSE));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_ARCOR));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_MOLINOS_RIO_DE_LA_PLATA));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_COCA_COLA));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_PEPSICO));
			fabricantes.Add(CrearFabricante(Constants.FABRICANTE_AGD));

			//CATEGORIAS
			categorias.Add(CrearCategoria(Constants.CATEGORIA_VINOS));   
			categorias.Add(CrearCategoria(Constants.CATEGORIA_GASEOSA));
			categorias.Add(CrearCategoria(Constants.CATEGORIA_FIDEOS));
			categorias.Add(CrearCategoria(Constants.CATEGORIA_ACEITES));


			// PRODUCTOS AGRUPADOS: Vinos
			
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_RESERVA_MALBEC, Constants.FABRICANTE_BODEGA_RUTINI, Constants.CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_GRAN_RESERVA_MALBEC, Constants.FABRICANTE_BODEGA_RUTINI, Constants.CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_CAROYENSE_MALBEC, Constants.FABRICANTE_LA_CAROYENSE, Constants.CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_CAROYENSE_CABERNET, Constants.FABRICANTE_LA_CAROYENSE, Constants.CATEGORIA_VINOS));

			// PRODUCTOS AGRUPADOS: Gaseosas			
			

			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_COCA_COLA, Constants.FABRICANTE_COCA_COLA, Constants.CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_AGRUPADOR_SPRITE, Constants.FABRICANTE_COCA_COLA, Constants.CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_PEPSI, Constants.FABRICANTE_PEPSICO, Constants.CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(Constants.PRODUCTO_SEVEN_UP, Constants.FABRICANTE_PEPSICO, Constants.CATEGORIA_GASEOSA));

			
			// PRODUCTOS: Vinos
			productos.Add(CrearProducto("Ruttini reserva Malbec 750cc", 11500, Constants.PRODUCTO_AGRUPADOR_RESERVA_MALBEC));
			productos.Add(CrearProducto("Ruttini gran reserva Malbec 750cc", 14500, Constants.PRODUCTO_AGRUPADOR_GRAN_RESERVA_MALBEC));

			productos.Add(CrearProducto("Bodega La Caroyense Malbec 375cc", 3500, Constants.PRODUCTO_AGRUPADOR_CAROYENSE_MALBEC));
			productos.Add(CrearProducto("Bodega La Caroyense Malbec 750cc", 6500, Constants.PRODUCTO_AGRUPADOR_CAROYENSE_MALBEC));

			productos.Add(CrearProducto("Bodega La Caroyense Cabernet 375cc", 3500, Constants.PRODUCTO_AGRUPADOR_CAROYENSE_CABERNET));
			productos.Add(CrearProducto("Bodega La Caroyense Cabernet 750cc", 6500, Constants.PRODUCTO_AGRUPADOR_CAROYENSE_CABERNET));

			// PRODUCTOS: Gaseosas
			productos.Add(CrearProducto("Coca Cola 1.5 L descartable", 1800, Constants.PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 2 L descartable", 2400, Constants.PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 1.25 L retornable", 1300, Constants.PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 2 L retornable", 1900, Constants.PRODUCTO_AGRUPADOR_COCA_COLA));

			productos.Add(CrearProducto("Sprite 1.5 L descartable", 1800, Constants.PRODUCTO_AGRUPADOR_SPRITE));
			productos.Add(CrearProducto("Sprite 2 L descartable", 2400, Constants.PRODUCTO_AGRUPADOR_SPRITE));
			productos.Add(CrearProducto("Sprite 1.25 L retornable", 1300, Constants.PRODUCTO_AGRUPADOR_SPRITE));
			productos.Add(CrearProducto("Sprite 2 L retornable", 1900, Constants.PRODUCTO_AGRUPADOR_SPRITE));

			productos.Add(CrearProducto("Pepsi 1.5 L descartable", 1800, Constants.PRODUCTO_PEPSI));
			productos.Add(CrearProducto("Pepsi 2 L descartable", 2400, Constants.PRODUCTO_PEPSI));
			productos.Add(CrearProducto("Pepsi 1.25 L retornable", 1300, Constants.PRODUCTO_PEPSI));
			productos.Add(CrearProducto("Pepsi 2 L retornable", 1900, Constants.PRODUCTO_PEPSI));

			productos.Add(CrearProducto("Seven up 1.5 L descartable", 1800, Constants.PRODUCTO_SEVEN_UP));
			productos.Add(CrearProducto("Seven up 2 L descartable", 2400, Constants.PRODUCTO_SEVEN_UP));
			productos.Add(CrearProducto("Seven up 1.25 L retornable", 1300, Constants.PRODUCTO_SEVEN_UP));
			productos.Add(CrearProducto("Seven up 2 L retornable", 1900, Constants.PRODUCTO_SEVEN_UP));


			// PROMOCIONES SIMPLES
			var categoriaVinos = categorias.First(c => c.Nombre == Constants.CATEGORIA_VINOS);

			var promo1 = CrearPromocionPrecioSimple("10 % descuento en vinos", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10), ObjetivoDePromocion.Categoria,
				null, null, categoriaVinos, null, TipoDeDescuento.Porcentaje, 10);
				
			promocionesSimples.Add(promo1);

			var fabricanteCocaCola = fabricantes.First(f => f.Nombre == Constants.FABRICANTE_COCA_COLA);
			var categoriaGaseosa = categorias.First(c => c.Nombre == Constants.CATEGORIA_GASEOSA);

			var promo2 = CrearPromocionPrecioSimple("20 % descuento en gaseosas de Coca Cola", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10), ObjetivoDePromocion.CategoriaYFabricante,
				null, null, categoriaGaseosa, fabricanteCocaCola, TipoDeDescuento.Porcentaje, 20);

			promocionesSimples.Add(promo2);


			var vinoEspecifico = productos.First(p => p.Nombre == "Bodega La Caroyense Cabernet 750cc");

			var promo3 = CrearPromocionPrecioSimple("Bodega La Caroyense Cabernet 750cc - Precio especial $5000", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10), ObjetivoDePromocion.Producto,
				vinoEspecifico, null, null, null, TipoDeDescuento.Precio, 5000);

			promocionesSimples.Add(promo3);

			// PROMOCIONES DE CONJUNTOS
			var seven2Lretornable = productos.First(p => p.Nombre == "Seven up 2 L retornable");
			var promoConjunto1 = CrearPromocionPrecioPorConjunto("2 x 1 en Seven 2L retornable", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10), seven2Lretornable, 2, 1);
			promocionesDeConjuntos.Add(promoConjunto1);
		}




		public Fabricante CrearFabricante(string nombre)
		{
			fabricanteId = fabricanteId + 1;
			var nuevo = new Fabricante()
			{
				Id = fabricanteId,
				Nombre = nombre
			};
			return nuevo;
		}

		public Categoria CrearCategoria(string nombre)
		{
			categoriasId = categoriasId + 1;
			var nuevo = new Categoria()
			{
				Id = categoriasId,
				Nombre = nombre
			};
			return nuevo;
		}

		public ProductoAgrupador CrearProductoAgrupador(string nombre, string nombreFabricante, string nombreCategoria)
		{
			productosAgrupadoresId = productosAgrupadoresId + 1;

			var fabricante = fabricantes.First(fabricante => fabricante.Nombre == nombreFabricante);
			var categoria = categorias.First(categoria => categoria.Nombre == nombreCategoria);

			var nuevo = new ProductoAgrupador()
			{
				Id = productosAgrupadoresId,
				Nombre = nombre,
				Fabricante = fabricante,
				Categoria = categoria
			};
			return nuevo;
		}

		public Producto CrearProducto(string nombre, double precio, string productoAgrupador)
		{
			productosId = productosId + 1;

			var agrupador = productosAgrupadores.First(p => p.Nombre == productoAgrupador);
			var nuevo = new Producto()
			{
				Id = productosId,
				Nombre = nombre,
				ProductoAgrupador = agrupador,
				PrecioVenta = precio
			};
			return nuevo;
		}

		public PromocionPrecioSimple CrearPromocionPrecioSimple(string nombrePromo, DateTime fechaDesde, DateTime fechaHasta, ObjetivoDePromocion objetivoDePromocion,
			Producto producto, ProductoAgrupador productoAgrupador, Categoria categoria, Fabricante fabricante,	TipoDeDescuento tipoDeDescuento, int valorDeDescuento)
		{
			promocionSimpleId = promocionSimpleId + 1;

			var promocion = new PromocionPrecioSimple() {
				Id = promocionSimpleId,
				Nombre = nombrePromo,
				FechaDesde = fechaDesde,
				FechaHasta = fechaHasta,
				ObjetivoDePromocion = objetivoDePromocion,
				Producto = producto,
				ProductoAgrupador = productoAgrupador,
				Categoria = categoria,
				Fabricante = fabricante,
				TipoDeDescuento = tipoDeDescuento,
				ValorDeDescuento = valorDeDescuento
			};
			
			return promocion;
		}
		
		public PromocionPreciosPorConjuntos CrearPromocionPrecioPorConjunto(string nombrePromo, DateTime fechaDesde, DateTime fechaHasta, 
			Producto producto, int cantidadConjunto, int cantidadDescontada)
		{
			promocionPreciosPorConjuntosId = promocionPreciosPorConjuntosId + 1;

			var promocion = new PromocionPreciosPorConjuntos()
			{
				Id = promocionPreciosPorConjuntosId,
				Nombre = nombrePromo,
				FechaDesde = fechaDesde,
				FechaHasta = fechaHasta,
				ObjetivoDePromocion = ObjetivoDePromocion.Producto,
				Producto = producto,				
				CantidadConjunto = cantidadConjunto,
				CantidadDescontada = cantidadDescontada
			};

			return promocion;
		}


		public List<Fabricante> ObtenerTodosLosFabricantes()
		{
			return fabricantes;
		}

		public List<Categoria> ObtenerTodoasLasCategorias()
		{
			return categorias;
		}

		public List<ProductoAgrupador> ObtenerTodosLosProductosAgrupadores()
		{
			return productosAgrupadores;
		}

		public List<Producto> ObtenerTodosLosProductos()
		{
			return productos;
		}

		public List<PromocionPrecioSimple> ObtenerPromocionesPrecioSimple()
		{
			return promocionesSimples;
		}

		public List<PromocionPreciosPorConjuntos> ObtenerPromocionesDeConjuntos()
		{
			return promocionesDeConjuntos;
		}
	}
}
