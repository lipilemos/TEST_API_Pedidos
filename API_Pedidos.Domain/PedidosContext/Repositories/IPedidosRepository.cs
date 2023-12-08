using API_Pedidos.Domain.Core.Results;
using API_Pedidos.Domain.PedidosContext.Entities;

namespace API_Pedidos.Domain.PedidosContext.Repositories
{
    public interface IPedidosRepository
    {
        Task<Result<IList<Pedido>>> GetAllAsync();
        Task<Result<Pedido>> GetByIdAsync(int id);
        Task<SimpleResult> AddAsync(Pedido pedido);
        Task<Result<Pedido>> UpdateAsync(Pedido pedido);
        Task<SimpleResult> RemoveAsync(int id);
    }

}