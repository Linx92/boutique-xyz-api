﻿namespace boutique_zyx_api.Entidades
{
    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime? FechaRecepcion { get; set; }
        public DateTime? FechaDespacho { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int Vendedor { get; set; }
        public int? Repartidor { get; set; }
        public int Estado { get; set; } // Por atender, En proceso, En delivery, Recibido
        public List<ProductoPedido> ProductoPedidos { get; set; }

    }
}
