namespace PuntoDeVenta.Entities
{
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

}
