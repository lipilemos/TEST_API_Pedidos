using API_Pedidos.Domain.PedidosContext.Entities;
using API_Pedidos.Test.Base;
using FluentAssertions;
using NUnit.Framework;

namespace API_Pedidos.Test.Tests.Domain.PedidosContext.Entities
{
    public class PedidoTests : UnitTestBase
    {
        [Test]
        public void Custructor_should_create_a_new_Id()
        {
            // Arrange
            var NomeCliente = "Felipe";
            var EmailCliente = "felipe@email.com";
            var Pago = true;
            var ItensPedido = new List<ItensPedido>();
            ItensPedido.Add(new ItensPedido { Quantidade = 2, Produto = new Produto { NomeProduto = "Shampoo", Valor = 23 } });

            var DataCriacao = new DateTime(2023, 01, 01);

            // Act
            var pedido = new Pedido();
            pedido.NomeCliente = NomeCliente;
            pedido.EmailCliente = EmailCliente;
            pedido.Pago = Pago;
            pedido.ItensPedido = ItensPedido;
            pedido.DataCriacao = DataCriacao;

            // Assert
            pedido.Id.Should().NotBe(0);
        }

        [Test]
        public void Constructor_should_set_all_properties_correctly()
        {
            // Arrange
            var NomeCliente = "Felipe";
            var EmailCliente = "felipe@email.com";
            var Pago = true;
            var ItensPedido = new List<ItensPedido>();
            ItensPedido.Add(new ItensPedido { Quantidade = 2, Produto = new Produto { NomeProduto = "Shampoo", Valor = 23 } });

            var DataCriacao = new DateTime(2023, 01, 01);

            // Act
            var pedido = new Pedido();
            pedido.NomeCliente = NomeCliente;
            pedido.EmailCliente = EmailCliente;
            pedido.Pago = Pago;
            pedido.ItensPedido = ItensPedido;
            pedido.DataCriacao = DataCriacao;

            // Assert
            pedido.NomeCliente.Should().Be("Felipe");
            pedido.EmailCliente.Should().Be("felipe@email.com");
            pedido.Pago.Should().Be(true);
            //pedido.ItensPedido.Should().Be(new List<ItensPedido>().Add(new ItensPedido { Quantidade = 2, Produto = new Produto { NomeProduto = "Shampoo", Valor = 23 } }));
            pedido.DataCriacao.Should().Be(new DateTime(2023, 01, 01));
        }
    }
}
