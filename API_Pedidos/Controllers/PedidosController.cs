using Microsoft.AspNetCore.Mvc;
using API_Pedidos.Domain.PedidosContext.Services;
using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Models;
using API_Pedidos.Domain.PedidosContext.Entities;
using AutoMapper;
using System.Collections.Generic;

namespace API_Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPedidosService _pedidosService;

        public PedidosController(
            IMapper mapper,
            IPedidosService pedidosService)
        {
            _mapper = mapper;
            _pedidosService = pedidosService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PedidoGetResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _pedidosService.GetPedidoByIdAsync(id);

            if (result.HasError)
                return BadRequest(result.Errors);

            if (result.Data == null)
                return NoContent();


            var pedidoModel = _mapper.Map<Pedido, PedidoGetResultModel>(result.Data);
            return Ok(pedidoModel);
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PedidoGetResultModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _pedidosService.GetAllAsync();

            if (result.HasError)
                return BadRequest(result.Errors);

            if (result.Data == null)
                return NoContent();

            var pedidoModels = _mapper.Map<IEnumerable<Pedido>, IEnumerable<PedidoGetResultModel>>(result.Data);

            return Ok(pedidoModels);
        }
        [HttpPost]
        [ProducesResponseType(typeof(PedidoGetResultModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync(PedidoPostRequestModel pedidoModel)
        {
            var pedido = _mapper.Map<PedidoPostRequestModel, Pedido>(pedidoModel);

            var result = await _pedidosService.CreateAsync(pedido);

            if (result.HasError)
                return BadRequest(result.Errors);

            return Created($"/pedidos/{pedido.Id}", pedido);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePedido(int id)
        {

            if (id == 0)
            {
                return NoContent();
            }
            var existingPedido = await _pedidosService.GetPedidoByIdAsync(id);

            if (existingPedido.HasError)
                return BadRequest(existingPedido.Errors);

            if (existingPedido.Data == null)
                return NotFound();

            var result = await _pedidosService.RemoveAsync(existingPedido.Data.Id);

            if (result.HasError)
                return BadRequest(result.Errors);

            return Ok();
        }
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PedidoGetResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(IReadOnlyCollection<Error>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync(int id, PedidoPutRequestModel pedidoModel)
        {
            var existingPedido = await _pedidosService.GetPedidoByIdAsync(id);

            if (existingPedido.HasError)
                return BadRequest(existingPedido.Errors);

            if (existingPedido.Data == null)
                return NotFound();


            // Atualiza as propriedades do pedido existente com base nos dados recebidos
            if (pedidoModel.NomeCliente != null)
                existingPedido.Data.NomeCliente = pedidoModel.NomeCliente;
            if (pedidoModel.EmailCliente != null)
                existingPedido.Data.EmailCliente = pedidoModel.EmailCliente;

            existingPedido.Data.Pago = pedidoModel.Pago;
            List<ItensPedido> novaLista = new List<ItensPedido>();
            // Atualiza os itens do pedido
            if (pedidoModel.ItensPedido != null)
                foreach (var itemModel in pedidoModel.ItensPedido)
                {
                    var existingItem = existingPedido.Data.ItensPedido.FirstOrDefault(i => i.Id == itemModel.Id);

                    if (existingItem != null)
                    {                       
                        // Atualiza as propriedades do item do pedido existente com base nos dados recebidos
                        //existingItem.IdProduto = itemModel.Produto.Id;
                        //existingItem.IdPedido = id;
                        existingItem.Quantidade = itemModel.Quantidade;
                        existingItem.Produto.Valor = itemModel.Produto.Valor;
                        existingItem.Produto.NomeProduto = itemModel.Produto.NomeProduto;
                        novaLista.Add(existingItem);
                    }
                    else
                    {

                        // Se o item não existir, pode ser necessário adicionr ou tratar conforme a lógica
                        // aqui estou adicionando um novo item com um novo produto
                         novaLista.Add(new ItensPedido { Quantidade = itemModel.Quantidade, Produto = new Produto { NomeProduto = itemModel.Produto.NomeProduto, Valor = itemModel.Produto.Valor } });
                    }
                }
            existingPedido.Data.ItensPedido = novaLista;

            var result = await _pedidosService.UpdateAsync(existingPedido.Data);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);

        }
    }
}
