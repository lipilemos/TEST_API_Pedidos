using API_Pedidos.Domain.PedidosContext.Entities;

namespace API_Pedidos.Models
{
    public class PedidoGetResultModel
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Pago { get; set; }
        public virtual decimal ValorTotal => CalcularValorTotal();
        public IList<ItensPedido> ItensPedido { get; set; }

        private decimal CalcularValorTotal()
        {
            return ItensPedido?.Sum(item => item.Produto.Valor * item.Quantidade) ?? 0;
        }

    }
}
