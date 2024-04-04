namespace PuntoDeVenta.Entities
{
    public class PromocionPreciosPorCantidad : PromocionBase, IPromocion
	{		
		public TipoDeDescuento TipoDePromocion { get; set; }

		public int ValorDeDescuento { get; set; }
		
		public int CantidadDesde { get; set; }
	}

}
