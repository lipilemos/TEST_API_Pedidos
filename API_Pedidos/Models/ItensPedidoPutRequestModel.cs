namespace API_Pedidos.Models
{
    public class ItensPedidoPutRequestModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public ProdutoPutRequestModel Produto { get; set; }   
    }
}
