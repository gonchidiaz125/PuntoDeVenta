namespace PuntoDeVenta.Entities
{
    public class PromocionPrecioSimple : PromocionBase, IPromocion
	{        			
		public TipoDeDescuento TipoDeDescuento { get; set; }

		public int ValorDeDescuento { get; set; }

		public string ObtenerDescripcionDelDescuento()
		{
			switch (TipoDeDescuento)
			{
				case TipoDeDescuento.Precio:
					return $"Valor final ${ValorDeDescuento}";

				case TipoDeDescuento.Porcentaje:
					return $"{ValorDeDescuento}% de descuento";
			
				default:
					throw new NotImplementedException();
			}			
		}
		
	}

}
