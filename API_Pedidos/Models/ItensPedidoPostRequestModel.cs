namespace API_Pedidos.Models
{
    public class ItensPedidoPostRequestModel
    {
        public int Quantidade { get; set; }
        public virtual ProdutoPostRequestModel Produto { get; set; }
    }
}
