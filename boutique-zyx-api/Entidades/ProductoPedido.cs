namespace boutique_zyx_api.Entidades
{
    public class ProductoPedido
    {
        public int NumeroPedido { get; set; }
        public string SKU { get; set; }
        public int Cantidad {  get; set; }
        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
