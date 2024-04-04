﻿using PuntoDeVenta.Entities;

var repositorios = new Repositorios();

// ImprimirDatos();
ImprimirPromociones();

CrearOrdenDeCompra();


void CrearOrdenDeCompra()
{
	var orden = new OrdenDeCompra();
	orden.Fecha = DateTime.Today;


	var producto = repositorios.ObtenerTodosLosProductos().First(p => p.Nombre == "Ruttini reserva Malbec 750cc");
	var item = new OrdenDeCompraDetalle(producto, 2, orden);
	orden.Items.Add(item);

	producto = repositorios.ObtenerTodosLosProductos().First(p => p.Nombre == "Bodega La Caroyense Malbec 750cc");
	item = new OrdenDeCompraDetalle(producto, 6, orden);
	orden.Items.Add(item);

	producto = repositorios.ObtenerTodosLosProductos().First(p => p.Nombre == "Bodega La Caroyense Cabernet 750cc");
	item = new OrdenDeCompraDetalle(producto, 3, orden);
	orden.Items.Add(item);

	producto = repositorios.ObtenerTodosLosProductos().First(p => p.Nombre == "Coca Cola 2 L descartable");
    item = new OrdenDeCompraDetalle(producto, 4, orden);
    orden.Items.Add(item);

    producto = repositorios.ObtenerTodosLosProductos().First(p => p.Nombre == "Pepsi 2 L descartable");
    item = new OrdenDeCompraDetalle(producto, 2, orden);
    orden.Items.Add(item);

    ImprimirOrdenDeCompra(orden);

	GenerarFactura(orden);
}

void ImprimirOrdenDeCompra(OrdenDeCompra orden)
{
	Console.WriteLine($"Orden de compra Nro: {orden.Id} - Fecha: {orden.Fecha}");
	Console.WriteLine("Productos:");
	Console.WriteLine("----------");
	foreach (var item in orden.Items )
	{
		Console.WriteLine($"{item.Cantidad.ToString("D3")}   {item.Producto.Nombre, -40} {item.Producto.PrecioVenta.ToString("F2")}  {(item.Cantidad * item.Producto.PrecioVenta).ToString("F2")} ");
	}
	Console.WriteLine("");
}

void ImprimirPromociones()
{
	Console.WriteLine("Promociones");
	Console.WriteLine("-----------");

	var promociones = repositorios.ObtenerPromocionesPrecioSimple();

	foreach (var promo in promociones)
	{
		Console.WriteLine($"ID: {promo.Id}  Nombre: {promo.Nombre}");
		Console.WriteLine($"Desde: {promo.FechaDesde} Hasta: {promo.FechaHasta}");
		Console.WriteLine($"Tipo: {promo.ObjetivoDePromocion.ToString()}   Objetivo: {promo.ObtenerObjetivoDePromocion()}");
		Console.WriteLine($"TipoDePromocion: {promo.TipoDeDescuento.ToString()} - {promo.ObtenerDescripcionDelDescuento()}");
		Console.WriteLine("");
	}
}

void GenerarFactura(OrdenDeCompra orden)
{
	var factura = new Factura();

	AplicarPromociones(orden, factura);

	ImprimirFactura(factura);
}

void AplicarPromociones(OrdenDeCompra orden, Factura factura)
{
	var promocionesSimples = repositorios.ObtenerPromocionesPrecioSimple();

	foreach (var promo in promocionesSimples)
	{
		promo.AplicarPromocion(factura, orden);
	}
}

void ImprimirFactura(Factura factura)
{
	Console.WriteLine("Descuentos");
	Console.WriteLine("----------");

	foreach (var dto in factura.Descuentos)
	{
		Console.WriteLine($"Descuento en {dto.Producto.Nombre} - Cantidad: {dto.Cantidad} * ${dto.DescuentoUnitario} - Total: {dto.Cantidad * dto.DescuentoUnitario}  - Promo aplicada: { dto.Promocion.Nombre }");
	}
}

void ImprimirDatos()
{	
	var fabricantes = repositorios.ObtenerTodosLosFabricantes();
	ImprimirListaViejo(fabricantes, "Fabricantes:");
	ImprimirLista(fabricantes, "Fabricantes:");

	Console.WriteLine("");

	var categorias = repositorios.ObtenerTodoasLasCategorias();
	ImprimirLista(categorias, "Categorias:");
	Console.WriteLine("");


	Console.WriteLine("Productos Agrupadores");
	Console.WriteLine("---------------------");
	var productosAgrupadores = repositorios.ObtenerTodosLosProductosAgrupadores();

	foreach (var aux in productosAgrupadores)
	{
		// Console.WriteLine($"Id: {aux.Id} - {aux.Nombre} - Fabricante: {aux.Fabricante.Nombre} ");
		Console.WriteLine($"{aux.Id.ToString("D8")}  {aux.Nombre,-40}  {aux.Categoria.Nombre, -20}   {aux.Fabricante.Nombre, -40}");
	}
	Console.WriteLine("");

	Console.WriteLine("Productos");
	Console.WriteLine("---------");
	var productos = repositorios.ObtenerTodosLosProductos();

	foreach (var aux in productos)
	{
		// Console.WriteLine($"Id: {aux.Id} - {aux.Nombre} - Categoria: {aux.ProductoAgrupador.Categoria.Nombre} Fabricante: {aux.ProductoAgrupador.Fabricante.Nombre} ");
		Console.WriteLine($"{aux.Id.ToString("D8")}  {aux.Nombre,-35} ${aux.PrecioVenta.ToString("F2")}  {aux.ProductoAgrupador.Nombre,-30} {aux.ProductoAgrupador.Categoria.Nombre,-12}  {aux.ProductoAgrupador.Fabricante.Nombre,-12}");
	}
	Console.WriteLine("");

	var vinos = productos.Where(p => p.ProductoAgrupador.Categoria.Nombre == "Vinos").ToList();
	ImprimirLista(vinos, "Vinos");
	Console.WriteLine("");

	var productosDeCocaColaCompany = productos.Where(p => p.ProductoAgrupador.Fabricante.Nombre == "Coca Cola Company").ToList();
	ImprimirLista(productosDeCocaColaCompany, "Coca cola fabrica:");
	Console.WriteLine("");
}

void ImprimirListaViejo<T>(List<T> lista, string titulo) where T : ClaseBase
{
	Console.WriteLine(titulo);
	Console.WriteLine("-------------");
	Console.WriteLine("Id        Nombre");

	foreach (var aux in lista)
	{
		Console.WriteLine($"Id: {aux.Id} - {aux.Nombre}");
	}
}

void ImprimirLista<T>(List<T> lista, string titulo) where T: ClaseBase
{
	Console.WriteLine(titulo);
	Console.WriteLine("-------------");
	Console.WriteLine("Id        Nombre");

	foreach (var aux in lista)
	{
		// Console.WriteLine($"Id: {aux.Id} - {aux.Nombre}");
		Console.WriteLine($"{aux.Id.ToString("D8")}  {aux.Nombre,-40}");
	}
}





