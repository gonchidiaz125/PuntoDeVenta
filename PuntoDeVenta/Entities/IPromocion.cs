namespace PuntoDeVenta.Entities
{
    public interface IPromocion
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public DateTime FechaDesde { get; set; }
		public DateTime FechaHasta { get; set; }

		public ObjetivoDePromocion ObjetivoDePromocion { get; set; }
	}

}
