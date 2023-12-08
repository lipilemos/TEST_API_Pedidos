namespace API_Pedidos.Models
{
    public class PedidoPostRequestModel
    {
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Pago { get; set; }
        public IList<ItensPedidoPostRequestModel> ItensPedido { get; set; }
    }
}
