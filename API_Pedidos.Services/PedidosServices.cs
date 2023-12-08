using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Domain.PedidosContext.Services;
using API_Pedidos.Domain.PedidosContext.Entities;
using API_Pedidos.Domain.PedidosContext.Repositories;

namespace API_Pedidos.Services.PedidosContext
{
    public class PedidosService : IPedidosService
    {
        private readonly IPedidosRepository _pedidoRepository;

        public PedidosService(IPedidosRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        
        public async Task<Result<Pedido>> GetPedidoByIdAsync(int id)
        {
            return await _pedidoRepository.GetByIdAsync(id);
        }
        public async Task<SimpleResult> CreateAsync(Pedido pedido)
        {
            return await _pedidoRepository.AddAsync(pedido);
        }
        public async Task<Result<IList<Pedido>>> GetAllAsync()
        {
            return await _pedidoRepository.GetAllAsync();
        }    
        public async Task<Result<Pedido>> UpdateAsync(Pedido pedido)
        {
            return await _pedidoRepository.UpdateAsync(pedido);
        }
        public async Task<SimpleResult> RemoveAsync(int id)
        {
            return await _pedidoRepository.RemoveAsync(id);
        }
    }
}