namespace PuntoDeVenta.Entities
{
    public class OrdenDeCompra : ClaseBase
	{
        public DateTime Fecha { get; set; }

		public List<OrdenDeCompraDetalle> Items { get; set; }

		public OrdenDeCompra()
		{
			Items = new List<OrdenDeCompraDetalle>();
		}

	}

}
