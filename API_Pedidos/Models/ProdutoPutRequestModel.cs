namespace API_Pedidos.Models
{
    public class ProdutoPutRequestModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Valor { get; set; }
    }

   
}
