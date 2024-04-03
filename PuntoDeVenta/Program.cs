using PuntoDeVenta.Entities;

var repositorios = new Repositorios();

ImprimirDatos();

void ImprimirDatos()
{	
	var fabricantes = repositorios.ObtenerTodosLosFabricantes();	
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
		Console.WriteLine($"{aux.Id.ToString("D8")}  {aux.Nombre,-30} ${aux.PrecioVenta.ToString("F2")}  {aux.ProductoAgrupador.Nombre,-25} {aux.ProductoAgrupador.Categoria.Nombre,-20}  {aux.ProductoAgrupador.Fabricante.Nombre,-20}");
	}
	Console.WriteLine("");


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





