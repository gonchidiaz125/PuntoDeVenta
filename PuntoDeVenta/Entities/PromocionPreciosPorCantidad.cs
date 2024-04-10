namespace PuntoDeVenta.Entities
{
    public class PromocionPreciosPorCantidad : PromocionBase, IPromocion
	{		
		public TipoDeDescuento tipoDePromocion { get; set; }

		public int valorDeDescuento { get; set; }
		
		public int cantidadDesde { get; set; }
	}

}
