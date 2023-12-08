namespace API_Pedidos.Domain.PedidosContext.Entities
{
    public class ItensPedido
    {
        public int Id { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }

    }
}
