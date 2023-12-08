namespace API_Pedidos.Models
{
    public class PedidoPutRequestModel
    {
        public string? NomeCliente { get; set; }
        public string? EmailCliente { get; set; }
        public bool Pago { get; set; }
        public IList<ItensPedidoPutRequestModel>? ItensPedido { get; set; }
    }

   
}
