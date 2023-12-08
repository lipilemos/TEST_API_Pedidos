using System;
using Moq;
using API_Pedidos.Infrastructure.Repositories;
using API_Pedidos.Services.PedidosContext;
using API_Pedidos.Domain.PedidosContext.Entities;
using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Domain.PedidosContext.Repositories;

namespace API_Pedidos.Test
{
    public class PedidoServiceTests
    {
        [Fact]
        public void CalcularTotalPedido_DeveRetornarTotalCorreto()
        {
            var pedidoRepositoryMock = new Mock<IPedidosRepository>();
            var pedidoService = new PedidosService(pedidoRepositoryMock.Object);

            // pedido fictício com alguns itens fictícios
            var pedido = new Pedido
            {
                Id = 1,
                ItensPedido = new List<ItensPedido>
                {
                    new ItensPedido { IdProduto = 1, Quantidade = 2, Produto = new Produto{Valor = 12, NomeProduto="Produto 1", Id=1} },
                    new ItensPedido { IdProduto = 2, Quantidade = 1, Produto = new Produto{Valor = 22, NomeProduto="Produto 2", Id=1}}
                }
            };

            pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync((int id) => Result<Pedido>.Ok(new Pedido
                   {
                       Id = id,
                       NomeCliente = "Nome do Cliente",
                       EmailCliente = "cliente@example.com",
                       DataCriacao = DateTime.Now,
                       Pago = true,
                       ItensPedido = new List<ItensPedido>
                       {
                           new ItensPedido
                           {
                               Id = 1,
                               IdPedido = id,
                               IdProduto = 1,
                               Quantidade = 2,
                               Produto = new Produto
                               {
                                   Id = 1,
                                   NomeProduto = "Produto 1",
                                   Valor = 12
                               }
                           },
                           new ItensPedido
                           {
                               Id = 2,
                               IdPedido = id,
                               IdProduto = 2,
                               Quantidade = 1,
                               Produto = new Produto
                               {
                                   Id = 2,
                                   NomeProduto = "Produto 2",
                                   Valor = 22
                               }
                           }
                       }
                   }));

            var totalPedido = pedido.ValorTotal;

            Assert.Equal(46, totalPedido); 
        }

    }
}