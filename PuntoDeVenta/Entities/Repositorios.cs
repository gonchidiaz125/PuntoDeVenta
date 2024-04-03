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


		public Repositorios() {
			InicializarDatos();
		}

		private void InicializarDatos()
		{		
			// Utilizo constantes porque para evitar repetir el mismo nombre multiples veces y facilitar el mantenimiento
			// FABRICANTES
			const string FABRICANTE_BODEGA_RUTINI = "Bodega Rutini";
			const string FABRICANTE_COCA_COLA = "Coca Cola Company";
			const string FABRICANTE_PEPSICO = "Pepsico";
			const string FABRICANTE_LA_CAROYENSE = "La Caroyense";
			const string FABRICANTE_ARCOR = "Arcor";
			const string FABRICANTE_MOLINOS_RIO_DE_LA_PLATA = "Molinos Rio de la Plata";
			const string FABRICANTE_AGD = "Aceitera General Deheza";

			fabricantes.Add(CrearFabricante(FABRICANTE_BODEGA_RUTINI));
			fabricantes.Add(CrearFabricante(FABRICANTE_LA_CAROYENSE));
			fabricantes.Add(CrearFabricante(FABRICANTE_ARCOR));
			fabricantes.Add(CrearFabricante(FABRICANTE_MOLINOS_RIO_DE_LA_PLATA));
			fabricantes.Add(CrearFabricante(FABRICANTE_COCA_COLA));
			fabricantes.Add(CrearFabricante(FABRICANTE_PEPSICO));
			fabricantes.Add(CrearFabricante(FABRICANTE_AGD));

			
			// CATEGORIAS
			const string CATEGORIA_VINOS = "Vinos";
			const string CATEGORIA_GASEOSA = "Gaseosas";
			const string CATEGORIA_FIDEOS = "Fideos";
			const string CATEGORIA_ACEITES = "Aceites";

			categorias.Add(CrearCategoria(CATEGORIA_VINOS));
			categorias.Add(CrearCategoria(CATEGORIA_GASEOSA));
			categorias.Add(CrearCategoria(CATEGORIA_FIDEOS));
			categorias.Add(CrearCategoria(CATEGORIA_ACEITES));


			// PRODUCTOS AGRUPADOS: Vinos
			const string PRODUCTO_AGRUPADOR_RESERVA_MALBEC = "Ruttini reserva Malbec";
			const string PRODUCTO_AGRUPADOR_GRAN_RESERVA_MALBEC = "Ruttini gran reserva Malbec";
			const string PRODUCTO_AGRUPADOR_CAROYENSE_MALBEC = "Bodega La Caroyense Malbec";
			const string PRODUCTO_AGRUPADOR_CAROYENSE_CABERNET = "Bodega La Caroyense Cabernet";

			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_RESERVA_MALBEC, FABRICANTE_BODEGA_RUTINI, CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_GRAN_RESERVA_MALBEC, FABRICANTE_BODEGA_RUTINI, CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_CAROYENSE_MALBEC, FABRICANTE_LA_CAROYENSE, CATEGORIA_VINOS));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_CAROYENSE_CABERNET, FABRICANTE_LA_CAROYENSE, CATEGORIA_VINOS));

			// PRODUCTOS AGRUPADOS: Gaseosas			
			const string PRODUCTO_AGRUPADOR_COCA_COLA = "Coca Cola";
			const string PRODUCTO_AGRUPADOR_SPRITE = "Sprite";
			const string PRODUCTO_PEPSI = "Pepsi";
			const string PRODUCTO_SEVEN_UP = "Seven up";

			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_COCA_COLA, FABRICANTE_COCA_COLA, CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_AGRUPADOR_SPRITE, FABRICANTE_COCA_COLA, CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_PEPSI, FABRICANTE_PEPSICO, CATEGORIA_GASEOSA));
			productosAgrupadores.Add(CrearProductoAgrupador(PRODUCTO_SEVEN_UP, FABRICANTE_PEPSICO, CATEGORIA_GASEOSA));


			// PRODUCTOS									
			productos.Add(CrearProducto("Coca Cola 1.5 L descartable", 1800, PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 2 L descartable", 2400, PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 1.25 L retornable", 1300, PRODUCTO_AGRUPADOR_COCA_COLA));
			productos.Add(CrearProducto("Coca Cola 2 L retornable", 1900, PRODUCTO_AGRUPADOR_COCA_COLA));
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
	}
}
